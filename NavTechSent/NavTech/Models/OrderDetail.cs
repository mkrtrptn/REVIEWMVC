using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavTech.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<int> ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}