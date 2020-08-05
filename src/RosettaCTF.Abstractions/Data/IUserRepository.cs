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
using System.Threading.Tasks;

namespace RosettaCTF.Data
{
    /// <summary>
    /// Provides an abstraction over querying and manipulating users and teams.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">ID of the user to retrieve.</param>
        /// <returns>Requested user.</returns>
        Task<IUser> GetUserAsync(long id);

        /// <summary>
        /// Creates a new user with specified parameters. This method will fail if a user with this name exists.
        /// </summary>
        /// <param name="username">Username for the user.</param>
        /// <param name="token">Discord OAuth2 authentication token.</param>
        /// <param name="refreshToken">Discord OAuth2 refresh token.</param>
        /// <param name="tokenExpiresAt">Exact timestamp at which this OAuth2 token expires.</param>
        /// <returns>Created user.</returns>
        Task<IUser> CreateUserAsync(string username, string token, string refreshToken, DateTimeOffset tokenExpiresAt);

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="id">ID of the user to delete.</param>
        /// <returns>A task encapsulating the operation.</returns>
        Task DeleteUserAsync(long id);

        /// <summary>
        /// Retrieves a team by its ID.
        /// </summary>
        /// <param name="id">ID of the team to retrieve.</param>
        /// <returns>Requested team.</returns>
        Task<ITeam> GetTeamAsync(long id);

        /// <summary>
        /// Creates a new team with specified parameters. This method will fail if a team with this name exists.
        /// </summary>
        /// <param name="name">Name for the team.</param>
        /// <returns>Created team.</returns>
        Task<ITeam> CreateTeamAsync(string name);

        /// <summary>
        /// Deletes a team by its ID.
        /// </summary>
        /// <param name="id">ID of the team to delete.</param>
        /// <returns>A task encapsulating the operation.</returns>
        Task DeleteTeamAsync(long id);

        /// <summary>
        /// Assigns a user to a team. A null team will unassign the user from the team.
        /// </summary>
        /// <param name="user">User to assign to the team.</param>
        /// <param name="team">Team to assign the user to. Null will unassign the user from the team.</param>
        /// <returns>A task encapsulating the operation.</returns>
        Task AssignTeamMembershipAsync(IUser user, ITeam team);

        /// <summary>
        /// Updates OAuth2 authentication data for a user.
        /// </summary>
        /// <param name="user">User to update authentication data for.</param>
        /// <param name="token">New Discord OAuth2 authentication token.</param>
        /// <param name="refreshToken">New Discord OAuth2 refresh token.</param>
        /// <param name="tokenExpiresAt">New expiration timestamp for the token.</param>
        /// <returns>A task encapsulating the operation.</returns>
        Task UpdateTokensAsync(IUser user, string token, string refreshToken, DateTimeOffset tokenExpiresAt);
    }
}