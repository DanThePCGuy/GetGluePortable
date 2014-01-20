using System.Collections.Generic;
using Newtonsoft.Json;

namespace GetGluePortable.Model
{
    public class Interaction
    {
        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("object")]
        public Object Object { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("reply_count")]
        public int ReplyCount { get; set; }

        [JsonProperty("flags")]
        public List<string> Flags { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("mentions")]
        public List<object> Mentions { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("media")]
        public Media Media { get; set; }
    }

    public class Interactions : List<Interaction>
    {
        
    }
}
