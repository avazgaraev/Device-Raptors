using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class prodsize
    {
        [Key]
        public int sizeid { get; set; }
        public string sizename { get; set; }
        public bool availability { get; set; }

        public int productid { get; set; }
        public virtual products Products { get; set; }
    }
}