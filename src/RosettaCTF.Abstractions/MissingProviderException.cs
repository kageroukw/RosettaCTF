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

namespace RosettaCTF
{
    /// <summary>
    /// Thrown whenever specified provider is not found in the registered provider list.
    /// </summary>
    public sealed class MissingProviderException : Exception
    {
        /// <summary>
        /// Gets the ID of the missing provider.
        /// </summary>
        public string ProviderId { get; }

        internal MissingProviderException(string id)
            : base("Specified provider is not present in registered provider collection.")
        {
            this.ProviderId = id;
        }
    }
}