using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class messages
    {
        [Key]
        public int messageid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string messagefrom { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string messageto { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string messagesubject { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string messagetext { get; set; }

        [Column(TypeName = "Smalldatetime")]
        public DateTime messagedate{ get; set; }
    }
}