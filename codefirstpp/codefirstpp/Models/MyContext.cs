using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace codefirstpp.Models
{
    public class MyContext :DbContext
    {
        public DbSet<emp> Emps { get; set; }
        public DbSet<dept> department { get; set; }
    }
}