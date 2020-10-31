// ISmashcastService.cs
//
// Author:
//       mac-dev <aphextwin@gamerunners.co>
//
// Copyright (c) 2020 

namespace Jagsa.Services
{
    using System.Threading.Tasks;

    using Jagsa.Models;

    public interface ISmashcastService
    {
        Task<Result<object>> FetchLiveStreamsAsync(string id);
    }
}
