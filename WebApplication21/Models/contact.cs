using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class contact
    {
        [Key]
        public int contactid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string contactname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string contactsurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(70)]
        public string contactemail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string contactphone { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(200)]
        public string contactsubject { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string contactmessage { get; set; }

        public DateTime contactdate{ get; set; }
    }
}