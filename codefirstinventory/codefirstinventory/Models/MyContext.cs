using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace codefirstinventory.Models
{
    public class MyContext : DbContext
    {
        public DbSet<category> categories { get; set; }
        public DbSet<product> products { get; set; }

        public DbSet<order> orders { get; set; }
    }
}