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
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RosettaCTF.Data;

namespace RosettaCTF.Services
{
    public sealed class ChallengeBootstrapperService : IHostedService
    {
        private IServiceProvider Services { get; }
        private RosettaConfigurationRoot Configuration { get; }
        private DatastoreImplementationSelector DatastoreSelector { get; }

        public ChallengeBootstrapperService(
            IServiceProvider services,
            IOptions<RosettaConfigurationRoot> config,
            DatastoreImplementationSelector dsiSelector)
        {
            this.Services = services;
            this.Configuration = config.Value;
            this.DatastoreSelector = dsiSelector;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            this.DatastoreSelector.InitializeCtfConfigurationLoaderProvider("yaml", this.Services);
            this.DatastoreSelector.InitializeDatabaseProvider(this.Configuration.Database.Type, this.Services);
            this.DatastoreSelector.InitializeCacheProvider(this.Configuration.Cache.Type, this.Services);

            using (var scope = this.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var repository = services.GetRequiredService<ICtfChallengeRepository>();
                var configLoader = services.GetRequiredService<ICtfConfigurationLoader>();
                var challenges = configLoader.LoadChallenges();

                await repository.InstallAsync(challenges, cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
