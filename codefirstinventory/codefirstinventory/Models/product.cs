using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace codefirstinventory.Models
{
    public class product
    {
        [Key]
        public int prodid { get; set; }
        public string proddesc { get; set; }
        public double prodprice { get; set; }
        public int cateid { get; set; }

        [ForeignKey("cateid")]
        public category category { get; set; }

        public ICollection<order> orders { get; set; }

    }
}