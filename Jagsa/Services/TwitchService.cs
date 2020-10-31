// Bootstrap.cs
//
// Author:
//       mac-dev <aphextwin@gamerunners.co>
//
// Copyright (c) 2020 

namespace Jagsa
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Jagsa.Models;
    using Jagsa.Services;

    using Microsoft.MobCAT.Converters;
    using Microsoft.MobCAT.Services;

    partial class TwitchService : BaseHttpService, ITwitchService
    {
        public TwitchService(HttpMessageHandler handler = null)
            : base(UrlConstants.TwitchApiUri, handler)
        {
            SetDefaultRequestHeaders(false,
                new KeyValuePair<string, string>(UrlConstants.ClientIDHeaderKey, ApiConstants.TwitchApiKey));

            Serializer = new NewtonsoftJsonSerializer();
        }

        public Task<Result<string>> FetchGameAsync(string game)
        {
            var query = $"games?name={game}";

            return default;
        }

        public Task<Result<ObservableCollection<object>>> FetchLiveStreamsAsync(string id)
        {
            var query = $"streams?game_id={id}";

            return default;
        }
    }
}