using Newtonsoft.Json;

namespace GetGluePortable.Model
{
    public class CheckedIn
    {
        [JsonProperty("total")]
        public double Total { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}
