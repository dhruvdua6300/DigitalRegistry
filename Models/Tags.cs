using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRegistry.Models
{
    public class Tags
    {
        public int id { get; set; }
        public string tag_text { get; set; }
        public string tag_type { get; set; }
        public int social_media_count { get; set; }
        public int mobile_app_count { get; set; }
        public int gallery_count { get; set; }
    }
}
