using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class prodsale
    {
        public string productname { get; set; }
        public int productstprice { get; set; }
        public int productndprice { get; set; }
        public string productimg { get; set; }
        public string productcategoryid { get; set; }
        public string productcategoryname { get; set; }
        public int Count { get; set; }
    }
}