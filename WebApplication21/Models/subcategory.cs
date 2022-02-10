using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class subcategory
    {
        [Key]
        public int SubcategoryId { get; set; }
        public String SubcategoryName { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category Category{ get; set; }

        public ICollection<products> Productss { get; set; }
    }
}