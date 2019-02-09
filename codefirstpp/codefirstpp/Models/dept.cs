using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace codefirstpp.Models
{
    [Table("department")]
    public class dept
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int did { get; set; }

        [Required]
        public string dname { get; set; }
    }
}