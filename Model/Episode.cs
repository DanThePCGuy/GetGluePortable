using System.Collections.Generic;
using Newtonsoft.Json;

namespace GetGluePortable.Model
{
    public class Episode
    {
        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("season")]
        public int Season { get; set; }

        [JsonProperty("object")]
        public Object Object { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("original_air_date")]
        public string OriginalAirDate { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("tms_id")]
        public string TmsId { get; set; }
    }
}
