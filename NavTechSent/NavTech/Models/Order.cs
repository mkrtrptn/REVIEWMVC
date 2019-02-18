using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavTech.Models
{
    public class Order
    {

        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public string OrderDate { get; set; }
        public string Buyer { get; set; }
        public Nullable<int> Status { get; set; }
        public virtual ICollection<OrderDetail> OrderInfoes { get; set; }


    }
}