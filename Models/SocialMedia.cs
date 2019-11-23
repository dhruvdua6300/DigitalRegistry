using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRegistry.Models
{
    public class SocialMedia
    {
        public int id { get; set; }
        public string organization { get; set; }
        public string account { get; set; }
        public string service_key { get; set; }
        public string short_description { get; set; }
        public string long_description { get; set; }
        public string service_display_name { get; set; }
        public string service_url { get; set; }
        public string language { get; set; }
    }
}
