using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DigitalRegistry.Models
{
    public class DigitalRegistryContext : DbContext
    {
        public DigitalRegistryContext (DbContextOptions<DigitalRegistryContext> options)
            : base(options)
        {
        }

        public DbSet<DigitalRegistry.Models.Result> Result { get; set; }
    }
}
