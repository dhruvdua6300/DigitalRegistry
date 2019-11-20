using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRegistry.Models
{
    public class Repository:IRepository
    {
        private readonly DigitalRegistryContext digitalRegistryContext;
            public Repository(DigitalRegistryContext context) {
            digitalRegistryContext = context;
            
        }

        public bool SaveResults(RootObject root) {
            bool anyNewRecordsInserted=false;
            foreach (Result c in root.results) {

                digitalRegistryContext.Result.Add(c);
                anyNewRecordsInserted = true;


            }
            digitalRegistryContext.SaveChanges();
            return true;

        }

    }
}
