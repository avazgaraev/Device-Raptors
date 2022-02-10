using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class prodimg
    {
        [Key]
        public int imgid { get; set; }
        public string imgname{ get; set; }
        public bool availability { get; set; }

        public int productid { get; set; }
        public virtual products Products { get; set; }
    }
}