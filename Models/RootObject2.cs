using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRegistry.Models
{
    public class RootObject2

    {

        [JsonProperty("metadata")]
        public Metadata metadata { get; set; }
        [JsonProperty("results")]
        public List<Result2> results { get; set; }
    }
}
