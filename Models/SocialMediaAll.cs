using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRegistry.Models
{
    

    public class Agency
    {
        public int id { get; set; }
        public string name { get; set; }
        public string info_url { get; set; }
    }

    public class Tag
    {
        public int id { get; set; }
        public string tag_text { get; set; }
    }

    public class Result3
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
        public List<Agency> agencies { get; set; }
        public List<Tag> tags { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class RootObject3
    {
        public Metadata metadata { get; set; }
        public List<Result3> results { get; set; }
    }

    public class TagsRoot
    {
        public Metadata metadata { get; set; }
        public List<Tags> results { get; set; }
    }

}
