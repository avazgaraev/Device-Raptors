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
    }
}