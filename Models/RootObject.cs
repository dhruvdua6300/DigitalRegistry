using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRegistry.Models
{
    public class RootObject
    {
        public Metadata metadata { get; set; }
        public List<Result> results { get; set; }
    }
}
