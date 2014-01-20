using System.Collections.Generic;
using Newtonsoft.Json;

namespace GetGluePortable.Model
{
    public class Vote
    {
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("mentions")]
        public List<Mention> Mentions { get; set; }
    }

    public class Votes : List<Vote>
    {
        
    }
}
