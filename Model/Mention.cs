using Newtonsoft.Json;

namespace GetGluePortable.Model
{
    public class Mention
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
