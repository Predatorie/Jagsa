// Bootstrap.cs
//
// Author:
//       mac-dev <aphextwin@gamerunners.co>
//
// Copyright (c) 2020 

namespace Jagsa
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Jagsa.Models;
    using Jagsa.Services;

    using Microsoft.MobCAT.Converters;
    using Microsoft.MobCAT.Services;

    public class SmashcastService : BaseHttpService, ISmashcastService
    {
        public SmashcastService(HttpMessageHandler handler = null)
           : base(ApiConstants.SmashcastApiKey, handler)
        {
            var headers = new[]
                {
                    new KeyValuePair<string, string>(UrlConstants.SmashcastSeoHeaderKey, UrlConstants.SmashcastSeo),
                    new KeyValuePair<string, string>(UrlConstants.AuthTokenHeaderKey, ApiConstants.SmashcastApiKey)
                };

            SetDefaultRequestHeaders(shouldClear: false, headers: headers);

            Serializer = new NewtonsoftJsonSerializer();
        }

        public Task<Result<object>> FetchLiveStreamsAsync(string id)
        {
            var query = $"media/live/list?game={id}";
            throw new System.NotImplementedException();
        }
    }
}