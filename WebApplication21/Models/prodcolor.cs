using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class prodcolor
    {
        [Key]
        public int colorid { get; set; }
        public string colorname { get; set; }
        public bool availability{ get; set; }

        public int productid { get; set; }
        public virtual products Products { get; set; }
    }
}