// SteamService.cs
//
// Author:
//       mac-dev <aphextwin@gamerunners.co>
//
// Copyright (c) 2020 

namespace Jagsa.Services
{
    using System;
    using System.Collections.ObjectModel;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Jagsa.Models;

    using Microsoft.MobCAT.Converters;
    using Microsoft.MobCAT.Services;

    public class SteamService : BaseHttpService, ISteamService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handler">Optional message handler</param>
        public SteamService(HttpMessageHandler handler = null)
            : base(UrlConstants.SteamApiUri, handler)
        {
            Serializer = new NewtonsoftJsonSerializer();
        }

        /// <summary>
        /// Fetch a steam users friends list.
        /// </summary>
        /// <param name="steamId">The steam users steam id.</param>
        /// <returns>A list of steam friends.</returns>
        public async Task<Result<Friendslist>> FetchFriendsAsync(string steamId, CancellationToken token)
        {
            var query =
                $"ISteamUser/GetFriendList/v0001/?key={ApiConstants.SteamApiKey}&steamid={steamId}&relationship=friend";
            var returnList = await this.GetAsync<Friendslist>(query, token);

            return Result.Ok(returnList);
        }

        /// <summary>
        /// Fetch a list of friend steam profiles.
        /// </summary>
        /// <param name="friends">A list of steam friends.</param>
        /// <returns>A list of steam friend profiles.</returns>
        public Task<Result<ObservableCollection<Profile>>> FetchFriendsProfileAsync(Friend[] friends, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetch a steam users game library (if public)
        /// </summary>
        /// <param name="steamId">The users steam id.</param>
        /// <param name="token">The cancellation toekn.</param>
        /// <returns>The users steam libary if set to public.</returns>
        public async Task<Result<GamesLibrary>> FetchLibraryAsync(string steamId, CancellationToken token)
        {
            var query =
               $"IPlayerService/GetOwnedGames/v0001/?key={ApiConstants.SteamApiKey}&include_appinfo=1&include_played_free_games=1&steamid={steamId}";
            var result = await this.GetAsync<GamesLibrary>(query, token);

            return Result.Ok(result);
        }

        /// <summary>
        /// Fetch a steam user profile using a steam id.
        /// </summary>
        /// <param name="steamId">The users steam id.</param>
        /// <returns>The users steam profile.</returns>
        public async Task<Result<Profile>> FetchProfileAsync(string steamId, CancellationToken token)
        {
            var query = $"ISteamUser/GetPlayerSummaries/v0002/?key={ApiConstants.SteamApiKey}&steamids={steamId}";

            var profile = await this.GetAsync<Profile>(query, token);
            if (profile.Response != null)
            {
                return Result.Ok(profile);
            }

            return Result.Fail<Profile>("Fetching Steam profile failed.");
        }
    }
}
