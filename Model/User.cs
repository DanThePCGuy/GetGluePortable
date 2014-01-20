using System.Collections.Generic;
using Newtonsoft.Json;

namespace GetGluePortable.Model
{
    public class User : Base
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("followers")]
        public int Followers { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("friends")]
        public int Friends { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Users : List<User>
    {
        
    }
}