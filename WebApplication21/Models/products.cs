using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class products
    {
        [Key]
        public int productsid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string productsname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string productmarka { get; set; }
        public short productstock { get; set; }
        public decimal productstprice { get; set; }
        public decimal productndprice { get; set; }
        public bool productavailable { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(240)]
        public string productimg { get; set; }

       

        public int Categoryid { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<salemove> Salemoves { get; set; }
    }

}