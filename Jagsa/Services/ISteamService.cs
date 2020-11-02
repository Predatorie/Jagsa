// ISteamService.cs
//
// Author:
//       mac-dev <aphextwin@gamerunners.co>
//
// Copyright (c) 2020 

namespace Jagsa.Services
{
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Threading.Tasks;

    using Jagsa.Models;

    public interface ISteamService
    {
        Task<Result<Profile>> FetchProfileAsync(string steamId, CancellationToken token);
        Task<Result<GamesLibrary>> FetchLibraryAsync(string steamId, CancellationToken token);
        Task<Result<ObservableCollection<Profile>>> FetchFriendsProfileAsync(Friend[] friends, CancellationToken token);
        Task<Result<Friendslist>> FetchFriendsAsync(string steamId, CancellationToken token);
    }
}
