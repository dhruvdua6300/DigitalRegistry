using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DigitalRegistry.Models;

namespace DigitalRegistry.Models
{
    public class DigitalRegistryContext : DbContext
    {
        public DigitalRegistryContext (DbContextOptions<DigitalRegistryContext> options)
            : base(options)
        {
        }

        public DbSet<DigitalRegistry.Models.Result> Result { get; set; }

        public DbSet<MobileApp> mobileApps { get; set; }

        public DbSet<Result2> Result2 { get; set; }

        public DbSet<DigitalRegistry.Models.Result3> Result3 { get; set; }

        public DbSet<SocialMedia> socialMedias { get; set; }

        public DbSet<DigitalRegistry.Models.Tags> Tags { get; set; }


        

    }
}
