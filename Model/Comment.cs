using System.Collections.Generic;
using Newtonsoft.Json;

namespace GetGluePortable.Model
{
    public class Comment
    {
        [JsonProperty("comment")]
        public string Text { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        //[JsonProperty("user")]
       // public User User { get; set; }

        [JsonProperty("mentions")]
        public List<Mention> Mentions { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Comments : List<Comment>
    {

    }
}
