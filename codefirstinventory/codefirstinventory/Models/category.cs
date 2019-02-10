using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace codefirstinventory.Models
{
    public class category
    {
        [Key]
        public int cateid { set; get; }
        public string catedesc { set; get; }

        public ICollection<product> products { get; set; }
    }
}