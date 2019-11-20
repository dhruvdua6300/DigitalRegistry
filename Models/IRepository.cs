using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRegistry.Models
{
    public interface IRepository
    {
        bool SaveResults(RootObject root);
    }
}
