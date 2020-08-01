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

namespace RosettaCTF.Data
{
    /// <summary>
    /// Provides an interface for loading challenges outlined for a
    /// </summary>
    public interface ICtfConfigurationLoader
    {
        /// <summary>
        /// Loads basic information about the event.
        /// </summary>
        /// <returns></returns>
        ICtfEvent LoadEventData();

        /// <summary>
        /// Loads all defined challenges.
        /// </summary>
        /// <returns>An enumerable of defined challenges, packed into categories.</returns>
        IEnumerable<ICtfChallengeCategory> LoadChallenges();
    }
}
