using Newtonsoft.Json;

namespace GetGluePortable.Model
{
    public class SimilarShow
    {
        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
