using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class prodcategory
    {
        public IEnumerable<products> pros { get; set; }
        public IEnumerable<Category> categories{ get; set; }
    }
}