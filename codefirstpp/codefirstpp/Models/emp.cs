using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace codefirstpp.Models
{
    public class emp
    {
        [Key]
        public int eid { get; set;}
        public string name { get; set; }
        public int did { get; set; }
        
        [ForeignKey("did")]
        public dept Dept { get; set; }

    }
}