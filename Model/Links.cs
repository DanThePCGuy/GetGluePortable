using Newtonsoft.Json;

namespace GetGluePortable.Model
{
    public class Links
    {
        [JsonProperty("itunes")]
        public string Itunes { get; set; }

        [JsonProperty("netflix")]
        public string Netflix { get; set; }

        [JsonProperty("hulu")]
        public string Hulu { get; set; }

        [JsonProperty("amazon")]
        public string Amazon { get; set; }

        [JsonProperty("huluplus")]
        public string HuluPlus { get; set; }

        [JsonProperty("trailer")]
        public string Trailer { get; set; }

        [JsonProperty("Fandango")]
        public string Fandango { get; set; }
    }
}
