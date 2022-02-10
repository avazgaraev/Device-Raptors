using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class catsubcat
    {
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<subcategory> sub { get; set; }
    }
}