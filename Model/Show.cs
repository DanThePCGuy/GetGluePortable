using System.Collections.Generic;
using Newtonsoft.Json;

namespace GetGluePortable.Model
{
    public class Show
    {
        [JsonProperty("meta_id")]
        public string MetaID { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("object")]
        public Object Object { get; set; }

        [JsonProperty("starts_at")]
        public string StartsAt { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("wants_to_watch")]
        public bool WantsToWatch { get; set; }

        [JsonProperty("callsign")]
        public string CallSign { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("tms_id")]
        public string TmsID { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("trailer_link")]
        public string TrailerLink { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("high_definition")]
        public bool HighDefinition { get; set; }

        [JsonProperty("qualifiers")]
        public List<string> Qualifiers { get; set; }

        [JsonProperty("similar")]
        public List<SimilarShow> SimilarShows { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("view")]
        public string View { get; set; }

        [JsonProperty("liked_friends")]
        public List<User> LikedFriends { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("checked_in")]
        public CheckedIn CheckedIn { get; set; }

        [JsonProperty("trending")]
        public Trending Trending { get; set; }

        [JsonProperty("episode")]
        public Episode Episode { get; set; }
    }

    public class Shows : List<Show>
    {
        
    }
}
