﻿// This file is part of RosettaCTF project.
//
// Copyright 2020 Emzi0767
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RosettaCTF.Data;
using RosettaCTF.Data.Scoring;
using RosettaCTF.Filters;
using RosettaCTF.Models;
using RosettaCTF.Services;

namespace RosettaCTF.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = JwtAuthenticationOptions.RoleParticipant + "," + JwtAuthenticationOptions.RoleTeamMember)]
    [ServiceFilter(typeof(ValidRosettaUserFilter))]
    [ServiceFilter(typeof(EventStartedFilter))]
    [ElapsedPopulatorFilter]
    [ValidateAntiForgeryToken]
    public sealed class ChallengeController : RosettaControllerBase
    {
        private ICtfChallengeRepository ChallengeRepository { get; }
        private ChallengePreviewRepository ChallengePreviewRepository { get; }
        private ICtfChallengeCacheRepository ChallengeCacheRepository { get; }
        private IScoringModel ScoringModel { get; }

        public ChallengeController(
            ILoggerFactory loggerFactory,
            IUserRepository userRepository,
            UserPreviewRepository userPreviewRepository,
            ICtfConfigurationLoader ctfConfigurationLoader,
            ICtfChallengeRepository challengeRepository,
            ChallengePreviewRepository challengePreviewRepository,
            ICtfChallengeCacheRepository challengeCacheRepository,
            IScoringModel scoringModel)
            : base(loggerFactory, userRepository, userPreviewRepository, ctfConfigurationLoader)
        {
            this.ChallengeRepository = challengeRepository;
            this.ChallengePreviewRepository = challengePreviewRepository;
            this.ChallengeCacheRepository = challengeCacheRepository;
            this.ScoringModel = scoringModel;
        }

        [HttpGet]
        [Route("categories")]
        public async Task<ActionResult<ApiResult<IEnumerable<ChallengeCategoryPreview>>>> GetCategories(CancellationToken cancellationToken = default)
        {
            var categories = await this.ChallengeRepository.GetCategoriesAsync(cancellationToken);
            var challengeIds = categories.SelectMany(x => x.Challenges)
                .Select(x => x.Id);

            var scores = await this.ChallengeCacheRepository.GetScoresAsync(challengeIds, cancellationToken);

            var rcategories = this.ChallengePreviewRepository.GetChallengeCategories(categories, this.Elapsed, this.RosettaUser.HasHiddenAccess, scores);
            return this.Ok(rcategories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ApiResult<ChallengePreview>>> GetChallenge(string id, CancellationToken cancellationToken = default)
        {
            var challenge = await this.ChallengeRepository.GetChallengeAsync(id, cancellationToken);
            var score = await this.ChallengeCacheRepository.GetScoreAsync(id, cancellationToken);

            var rchallenge = this.ChallengePreviewRepository.GetChallenge(challenge, this.Elapsed, score);
            return this.Ok(rchallenge);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<ActionResult<ApiResult<bool>>> SubmitFlag([FromRoute] string id, [FromBody] ChallengeFlagModel challengeFlag, CancellationToken cancellationToken = default)
        {
            var challenge = await this.ChallengeRepository.GetChallengeAsync(id, cancellationToken);
            var flag = challengeFlag.Flag;
            var valid = flag == challenge.Flag;

            if (valid)
            {
                var solves = await this.ChallengeCacheRepository.IncrementSolveCountAsync(challenge.Id, cancellationToken);
                var baseline = await this.ChallengeCacheRepository.GetBaselineSolveCountAsync(cancellationToken);
                var rate = solves / (double)baseline;
                var score = this.ScoringModel.ComputeScore(challenge.BaseScore, rate);

                await this.ChallengeCacheRepository.UpdateScoreAsync(challenge.Id, score, cancellationToken);
            }

            try
            {
                await this.ChallengeRepository.SubmitSolveAsync(flag, valid, challenge.Id, this.RosettaUser.Id, this.RosettaUser.Team.Id, null, cancellationToken);
            }
            catch
            { return this.Conflict(ApiResult.FromError<bool>(new ApiError(ApiErrorCode.AlreadySolved, "Your team already solved this challenge."))); }

            return this.Ok(ApiResult.FromResult(valid));
        }
    }
}
