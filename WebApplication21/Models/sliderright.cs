using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class sliderright
    {
        [Key]
        public int sliderid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string sliderimg { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string sliderheader { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string slidertoprod { get; set; }

        
    }
}