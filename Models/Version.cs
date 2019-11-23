using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRegistry.Models
{
    public class Version
    {
        [Key]
        public int id{ get; set; }
        public string store_url { get; set; }
        public string platform { get; set; }
        public string version_number { get; set; }
        public DateTime? publish_date { get; set; }
        public string screenshot { get; set; }
        public string device { get; set; }
        public string average_rating { get; set; }
        public int? number_of_ratings { get; set; }
    }
}
