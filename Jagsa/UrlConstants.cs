// UrlConstants.cs
//
// Author:
//       mac-dev <Predatorie@live.com>
//
// Copyright (c) 2020 

namespace Jagsa
{
    public static class UrlConstants
    {
        // dev.twitch.tv application settings
        public const string TwitchApiUri = "https://api.twitch.tv/";
        public const string TwitchPlaylistApiUri = "https://usher.ttvnw.net/";
        public const string ClientIDHeaderKey = "Client-ID";

        public const string SteamApiUri = "https://api.steampowered.com/";
        public const string SteamMediaUri = "http://media.steampowered.com/steamcommunity/public/images/apps/";

        public const string SmashcastApiUri = "https://api.smashcast.tv/";
        public const string SmashcastMediaUri = "https://edge.sf.hitbox.tv";
        public const string AuthTokenHeaderKey = "authToken";

        // 	If using a game name, this must be true
        public const string SmashcastSeoHeaderKey = "seo";
        public const string SmashcastSeo = "0";

        /// <summary>
        /// Just Another Game Streaming App
        /// </summary>
        public static string AppName = "Jagsa";
    }
}
