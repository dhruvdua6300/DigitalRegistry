using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRegistry.Models
{
    public class Result2
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("short_description")]
        public string short_description { get; set; }
        [JsonProperty("long_description")]
        public string long_description { get; set; }
        [JsonProperty("icon_url")]
        public string icon_url { get; set; }
        [JsonProperty("language")]
        public string language { get; set; }
        [JsonProperty("agencies")]
        public List<Agency> agencies { get; set; }
        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }
        [JsonProperty("versions")]
        public List<Version> versions { get; set; }
        [JsonProperty("created_at")]

        
        public DateTime? created_at { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? updated_at { get; set; }
    }
}
