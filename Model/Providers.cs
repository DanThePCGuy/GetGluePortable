using System.Collections.Generic;
using Newtonsoft.Json;

namespace GetGluePortable.Model
{
    public class Providers
    {
        [JsonProperty("ota")]
        public Ota Ota { get; set; }

        [JsonProperty("satellite")]
        public List<Satellite> Satellite { get; set; }

        [JsonProperty("cable")]
        public List<Cable> Cable { get; set; }
    }
}
