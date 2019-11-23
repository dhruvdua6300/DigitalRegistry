using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRegistry.Models
{
    public class MobileApp
    {
        public int id { get; set; }
        public string name { get; set; }
        public string short_description { get; set; }
        public string long_description { get; set; }
        public string icon_url { get; set; }
        public string language { get; set; }
    }
}
