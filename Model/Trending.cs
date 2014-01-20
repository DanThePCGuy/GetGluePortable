using Newtonsoft.Json;

namespace GetGluePortable.Model
{
    public class Trending
    {
        [JsonProperty("total")]
        public double Total { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}
