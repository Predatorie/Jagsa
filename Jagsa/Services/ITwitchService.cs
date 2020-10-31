// ITwitchService.cs
//
// Author:
//       mac-dev <aphextwin@gamerunners.co>
//
// Copyright (c) 2020 

namespace Jagsa.Services
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    using Jagsa.Models;

    public interface ITwitchService
    {
        Task<Result<string>> FetchGameAsync(string game);
        Task<Result<ObservableCollection<object>>> FetchLiveStreamsAsync(string id);
    }
}
