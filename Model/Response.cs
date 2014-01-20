using Newtonsoft.Json;

namespace GetGluePortable.Model
{
    internal class Response 
    {
        public User User { get; set; }

        public Object Object { get; set; }

        public Objects Objects { get; set; }

        public Interaction Interaction { get; set; }

        [JsonProperty("providers_list")]
        public Providers Providers { get; set; }
    }
}
