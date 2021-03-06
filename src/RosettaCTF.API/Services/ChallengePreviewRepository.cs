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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using RosettaCTF.Data;
using RosettaCTF.Models;

namespace RosettaCTF.Services
{
    /// <summary>
    /// Contains methods for querying and manipulating abridged versions of challenges and categories.
    /// </summary>
    public sealed class ChallengePreviewRepository
    {
        private EnumDisplayConverter EnumDisplayConverter { get; }

        /// <summary>
        /// Creates a new repository.
        /// </summary>
        /// <param name="enumCv">Enum display value converter to use for converting display values.</param>
        public ChallengePreviewRepository(EnumDisplayConverter enumCv)
        {
            this.EnumDisplayConverter = enumCv;
        }

        /// <summary>
        /// Converts a <see cref="ICtfChallenge"/> to its abridged variant.
        /// </summary>
        /// <param name="challenge">Challenge to convert.</param>
        /// <param name="elapsed">Time elapsed since the beginning of the event.</param>
        /// <returns>An abridged challenge.</returns>
        public ChallengePreview GetChallenge(ICtfChallenge challenge, TimeSpan elapsed)
            => this.GetChallenge(challenge, elapsed, null);

        /// <summary>
        /// Converts a <see cref="ICtfChallenge"/> to its abridged variant.
        /// </summary>
        /// <param name="challenge">Challenge to convert.</param>
        /// <param name="elapsed">Time elapsed since the beginning of the event.</param>
        /// <param name="score">Current score for this challenge.</param>
        /// <returns>An abridged challenge.</returns>
        public ChallengePreview GetChallenge(ICtfChallenge challenge, TimeSpan elapsed, int? score)
            => this.GetChallenge(challenge, elapsed, score, null);

        /// <summary>
        /// Converts a <see cref="ICtfChallenge"/> to its abridged variant.
        /// </summary>
        /// <param name="challenge">Challenge to convert.</param>
        /// <param name="elapsed">Time elapsed since the beginning of the event.</param>
        /// <param name="score">Current score for this challenge.</param>
        /// <param name="solved">Whether the currently-logged in user's team solved the challenge.</param>
        /// <returns>An abridged challenge.</returns>
        public ChallengePreview GetChallenge(ICtfChallenge challenge, TimeSpan elapsed, int? score, bool? solved)
            => new ChallengePreview(challenge, elapsed, this.EnumDisplayConverter, score, solved);

        /// <summary>
        /// Converts a <see cref="ICtfChallengeCategory"/> to its abridged variant.
        /// </summary>
        /// <param name="category">Category to convert.</param>
        /// <param name="elapsed">Time elapsed since the beginning of the event.</param>
        /// <returns>An abridged challenge category.</returns>
        public ChallengeCategoryPreview GetChallengeCategory(ICtfChallengeCategory category, TimeSpan elapsed)
            => this.GetChallengeCategory(category, elapsed, null);

        /// <summary>
        /// Converts a <see cref="ICtfChallengeCategory"/> to its abridged variant with specified scoring.
        /// </summary>
        /// <param name="category">Category to convert.</param>
        /// <param name="elapsed">Time elapsed since the beginning of the event.</param>
        /// <param name="scores">Scores for the challenges herein.</param>
        /// <returns>An abridged challenge category.</returns>
        public ChallengeCategoryPreview GetChallengeCategory(ICtfChallengeCategory category, TimeSpan elapsed, IReadOnlyDictionary<string, int> scores)
            => this.GetChallengeCategory(category, elapsed, scores, null);

        /// <summary>
        /// Converts a <see cref="ICtfChallengeCategory"/> to its abridged variant with specified scoring.
        /// </summary>
        /// <param name="category">Category to convert.</param>
        /// <param name="elapsed">Time elapsed since the beginning of the event.</param>
        /// <param name="scores">Scores for the challenges herein.</param>
        /// <param name="solveIds">IDs of challenges solved by current user's team.</param>
        /// <returns>An abridged challenge category.</returns>
        public ChallengeCategoryPreview GetChallengeCategory(
            ICtfChallengeCategory category,
            TimeSpan elapsed,
            IReadOnlyDictionary<string, int> scores,
            HashSet<string> solveIds)
            => new ChallengeCategoryPreview(category, elapsed, this.EnumDisplayConverter, scores, solveIds);

        /// <summary>
        /// Converts an enumerable of <see cref="ICtfChallengeCategory"/> to an enumerable of its abridged variants.
        /// </summary>
        /// <param name="categories">Enumerable of categories to convert.</param>
        /// <param name="elapsed">Time elapsed since the beginning of the event.</param>
        /// <returns>An enumerable of abridged challenge categories.</returns>
        public IEnumerable<ChallengeCategoryPreview> GetChallengeCategories(IEnumerable<ICtfChallengeCategory> categories, TimeSpan elapsed)
            => this.GetChallengeCategories(categories, elapsed, null);

        /// <summary>
        /// Converts an enumerable of <see cref="ICtfChallengeCategory"/> to an enumerable of its abridged variants with specified scoring.
        /// </summary>
        /// <param name="categories">Enumerable of categories to convert.</param>
        /// <param name="elapsed">Time elapsed since the beginning of the event.</param>
        /// <param name="scores">Scores for the challenges herein.</param>
        /// <returns>An enumerable of abridged challenge categories.</returns>
        public IEnumerable<ChallengeCategoryPreview> GetChallengeCategories(IEnumerable<ICtfChallengeCategory> categories, TimeSpan elapsed, IReadOnlyDictionary<string, int> scores)
            => this.GetChallengeCategories(categories, elapsed, scores, null);

        /// <summary>
        /// Converts an enumerable of <see cref="ICtfChallengeCategory"/> to an enumerable of its abridged variants with specified scoring.
        /// </summary>
        /// <param name="categories">Enumerable of categories to convert.</param>
        /// <param name="elapsed">Time elapsed since the beginning of the event.</param>
        /// <param name="scores">Scores for the challenges herein.</param>
        /// <param name="solveIds">IDs </param>
        /// <param name="solveIds">IDs of challenges solved by current user's team.</param>
        public IEnumerable<ChallengeCategoryPreview> GetChallengeCategories(
            IEnumerable<ICtfChallengeCategory> categories,
            TimeSpan elapsed,
            IReadOnlyDictionary<string, int> scores,
            HashSet<string> solveIds)
            => categories.Select(x => this.GetChallengeCategory(x, elapsed, scores, solveIds))
                .ToList();

        /// <summary>
        /// Converts an enumerable of <see cref="ICtfSolveSubmission"/> to a descendingly-ordered scoreboard.
        /// </summary>
        /// <param name="solves">Solves to convert into a scoreboard.</param>
        /// <param name="scores">Scores for individual challenges.</param>
        /// <param name="teams">Mapped teams for the scoreboard.</param>
        /// <returns>Constructed scoreboard.</returns>
        public IEnumerable<ScoreboardEntryPreview> GetScoreboard(
            IEnumerable<ICtfSolveSubmission> solves,
            IReadOnlyDictionary<string, int> scores,
            IReadOnlyDictionary<long, TeamPreview> teams)
            => solves.GroupBy(x => x.Team.Id)
                .Select(x =>
                {
                    var score = x.Sum(x => x.Score);
                    if (score == 0 || score == null)
                        score = x.Sum(x => scores?[x.Challenge.Id] ?? 0);

                    return new { team = teams[x.Key], score = score.Value };
                })
                .OrderByDescending(x => x.score)
                .Select((x, i) => new ScoreboardEntryPreview(x.team, x.score, i + 1, null))
                .ToList();

        /// <summary>
        /// Converts an enumerable of <see cref="ICtfSolveSubmission"/> to a descendingly-ordered scoreboard.
        /// </summary>
        /// <param name="solves">Solves to convert into a scoreboard.</param>
        /// <param name="scores">Scores for individual challenges.</param>
        /// <param name="teams">Mapped teams for the scoreboard.</param>
        /// <param name="startTime">Event start time for elapsed computation.</param>
        /// <returns>Constructed scoreboard.</returns>
        public IEnumerable<ScoreboardEntryPreview> GetScoreboard(
            IEnumerable<ICtfSolveSubmission> solves, 
            IReadOnlyDictionary<string, int> scores, 
            IReadOnlyDictionary<long, TeamPreview> teams,
            DateTimeOffset startTime)
            => solves.GroupBy(x => x.Team.Id)
                .Select(x =>
                {
                    var score = x.Sum(x => x.Score);
                    if (score == 0 || score == null)
                        score = x.Sum(x => scores?[x.Challenge.Id] ?? 0);

                    return new { team = teams[x.Key], score = score.Value, timestamp = x.SingleOrDefault()?.Timestamp };
                })
                .OrderByDescending(x => x.score)
                .Select((x, i) => new ScoreboardEntryPreview(x.team, x.score, i + 1, x.timestamp != null ? x.timestamp - startTime : null))
                .ToList();

        /// <summary>
        /// Converts an enumerable of <see cref="ICtfSolveSubmission"/> to a descendingly-ordered scoreboard.
        /// </summary>
        /// <param name="solves">Solves to convert into a scoreboard.</param>
        /// <param name="scores">Scores for individual challenges.</param>
        /// <param name="team">Mapped team for the scoreboard.</param>
        /// <param name="startTime">Event start time for elapsed computation.</param>
        /// <returns>Constructed scoreboard.</returns>
        public IEnumerable<ScoreboardEntryPreview> GetScoreboard(
            IEnumerable<ICtfSolveSubmission> solves,
            IReadOnlyDictionary<string, int> scores,
            DateTimeOffset startTime,
            IReadOnlyDictionary<long, UserPreview> users)
            => solves.Select(x =>
                {
                    var score = x.Score;
                    if (score == 0 || score == null)
                        score = scores?[x.Challenge.Id] ?? 0;

                    return new { score = score.Value, challenge = x.Challenge, timestamp = x.Timestamp, user = users?[x.User.Id] };
                })
                .OrderBy(x => x.timestamp)
                .Select((x, i) => new ScoreboardEntryPreview(this.GetChallenge(x.challenge, TimeSpan.Zero), x.user, x.score, i + 1, x.timestamp - startTime))
                .ToList();
    }
}
