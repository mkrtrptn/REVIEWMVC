using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavTech.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Weight { get; set; }
        public Nullable<int> Height { get; set; }
        public string Imagepath { get; set; }
        public string SKU { get; set; }
        public Nullable<long> Barcode { get; set; }
        public Nullable<int> AvailableQuantity {get; set;}

        public virtual ICollection<OrderDetail> OrderInfoes { get; set; }


    }


}