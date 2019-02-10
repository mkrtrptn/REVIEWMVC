using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace codefirstinventory.Models
{
    public class order
    {
        [Key]
        public int orderid { get; set; }
        public double quantity { get; set; }

        public int prodid { get; set; }

        public double bill { get; set; }
        
        public ICollection<product> products { get; set; }

    }
}