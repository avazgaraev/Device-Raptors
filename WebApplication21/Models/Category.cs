using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApplication21.Models;

namespace WebApplication21.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

       


        [Display(Name = "Category Name")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        public string SubCategoryName { get; set; }

        public int Parentid { get; set; }

        public virtual ICollection<subcategory> Subcategories { get; set; }
        

}
}

