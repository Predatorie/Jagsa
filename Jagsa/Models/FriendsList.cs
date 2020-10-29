// FriendsList.cs
//
// Author:
//       mac-dev <aphextwin@gamerunners.co>
//
// Copyright (c) 2020 

namespace Jagsa.Models
{
    using Newtonsoft.Json;

    public partial class FriendsList
    {
        [JsonProperty("friendslist")]
        public Friendslist Friendslist { get; set; }
    }

    public partial class Friendslist
    {
        [JsonProperty("friends")]
        public Friend[] Friends { get; set; }
    }

    public partial class Friend
    {
        [JsonProperty("steamid")]
        public string Steamid { get; set; }

        [JsonProperty("relationship")]
        public string Relationship { get; set; }

        [JsonProperty("friend_since")]
        public long FriendSince { get; set; }
    }
}
