using ExtraEdge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraEdge.Database
{
    public class MobileOwnerContext : DbContext
    {
        public MobileOwnerContext(DbContextOptions<MobileOwnerContext> options) : base(options)
        {

        }

        //Here we can first put the all our dbset with models
        //public DbSet<WeakReference> weakReferences { get; set; }
        public DbSet<MobileShopModel> mobileShopModels { get; set; }
    }
}
