using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRegistry.Models
{
    public class Result
    {
        public int id { get; set; }
        public string name { get; set; }
        public string info_url { get; set; }
        public int mobile_app_count { get; set; }
        public int social_media_count { get; set; }
        public int gallery_count { get; set; }
    }
}
