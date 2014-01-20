using Newtonsoft.Json;

namespace GetGluePortable.Model
{
    public class Images
    {
        [JsonProperty("avatar_large")]
        public string AvatarLarge { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("cast")]
        public string Cast { get; set; }

        [JsonProperty("wide")]
        public string Wide { get; set; }

        [JsonProperty("square")]
        public string Square { get; set; }

        [JsonProperty("iphone")]
        public string Iphone { get; set; }

        [JsonProperty("cast_retina")]
        public string CastRetina { get; set; }

        [JsonProperty("normal")]
        public string Normal { get; set; }

        [JsonProperty("extra_large")]
        public string ExtraLarge { get; set; }

        [JsonProperty("banner")]
        public string Banner { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("header_small")]
        public string HeaderSmall { get; set; }
    }
}
