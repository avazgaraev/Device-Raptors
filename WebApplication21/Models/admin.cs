using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class admin
    {
        [Key]
        public int adminid{ get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string adminname{ get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string adminpass{ get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string adminuse{ get; set; }

    }
}