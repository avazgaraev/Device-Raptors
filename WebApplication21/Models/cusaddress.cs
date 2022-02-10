using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class cusaddress
    {
        [Key]
        public int addressid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string addstate { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string addcity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string address { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string zipcode { get; set; }

        public int customerid  { get; set; }
        public virtual customer Customer { get; set; }
    }
}