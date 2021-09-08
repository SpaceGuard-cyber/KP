using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace KP
{
    class AppContext : DbContext
    {
        public DbSet<DataUser> DataUsers { get; set; }

        public DbSet<ProfileUser> Users { get; set; }

        public AppContext() : base("KPEntities")
        { 
            
        }
    }
}
