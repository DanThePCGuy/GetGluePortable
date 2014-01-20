using Newtonsoft.Json;

namespace GetGluePortable.Model
{
    public class Satellite
    {
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("headend_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
