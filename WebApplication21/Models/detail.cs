using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class Detail
    {
        [Key]
        public int Deatilid { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string productname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(3000)]
        public string productdetail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(400)]
        public string shortdetail { get; set; }

        public int productid{ get; set; }
        public virtual products products { get; set; }
    }
}