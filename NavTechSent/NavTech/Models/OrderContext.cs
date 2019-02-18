using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace NavTech.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("name=OrderDB")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            
        }
   
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> Orderdetails { get; set; }
    }
}