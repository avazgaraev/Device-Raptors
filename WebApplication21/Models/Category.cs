using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Display(Name ="Category Name")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CategoryName { get; set; }
        public ICollection<products> Productss{ get; set; }
    }
}