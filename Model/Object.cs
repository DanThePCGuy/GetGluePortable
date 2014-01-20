using System.Collections.Generic;
using Newtonsoft.Json;

namespace GetGluePortable.Model
{
    public class Object
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("huluplus_link")]
        public string HuluPlusLink { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("trailer_link")]
        public string TrailerLink { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("object_key")]
        public string ObjectKey { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("trending")]
        public Trending Trending { get; set; }

        [JsonProperty("rating_code")]
        public string RatingCode { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("director")]
        public string Director { get; set; }

        [JsonProperty("starring")]
        public List<string> Starring { get; set; }

        [JsonProperty("tms_id")]
        public string TmsId { get; set; }

        [JsonProperty("image_wide")]
        public string ImageWide { get; set; }

        [JsonProperty("netflix_link")]
        public string NetflixLink { get; set; }

        [JsonProperty("amazon_link")]
        public string AmazonLink { get; set; }

        [JsonProperty("image_thumbnail")]
        public string ImageThumbnail { get; set; }

        [JsonProperty("hulu_link")]
        public string HuluLink { get; set; }

        [JsonProperty("image_normal")]
        public string ImageNormal { get; set; }

        [JsonProperty("itunes_link")]
        public string ItunesLink { get; set; }
    }

    public class Objects : List<Object>
    {
        
    }
}
