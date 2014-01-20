using Newtonsoft.Json;

namespace GetGluePortable.Model
{
    public class Stats
    {
        [JsonProperty("replied")]
        public int Replied { get; set; }

        [JsonProperty("favorited")]
        public int Favorited { get; set; }

        [JsonProperty("liked")]
        public int Liked { get; set; }

        [JsonProperty("checked_in")]
        public int CheckedIn { get; set; }

        [JsonProperty("stickers_earned")]
        public int StickersEarned { get; set; }

        [JsonProperty("guru")]
        public int Guru { get; set; }

        [JsonProperty("commented")]
        public int Commented { get; set; }

        [JsonProperty("reviewed")]
        public int Reviewed { get; set; }

        [JsonProperty("invites")]
        public int Invites { get; set; }

        [JsonProperty("disliked")]
        public int Disliked { get; set; }

        [JsonProperty("saved")]
        public int Saved { get; set; }

        [JsonProperty("reviews")]
        public int Reviews { get; set; }

        [JsonProperty("checkins")]
        public int Checkins { get; set; }

        [JsonProperty("dislikes")]
        public int Dislikes { get; set; }

        [JsonProperty("likes")]
        public int Likes { get; set; }

        [JsonProperty("flagged")]
        public bool Flagged { get; set; }
    }
}