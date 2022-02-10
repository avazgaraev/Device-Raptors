using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class basket
    {
        public int basketid { get; set; }
        public string prodname{ get; set; }
        public int prodid{ get; set; }
        public string prodimg{ get; set; }
        public string prodcolor{ get; set; }
        public string prodsize{ get; set; }
        public decimal price{ get; set; }
        public int quantity{ get; set; }
        public decimal subtotoal{ get; set; }
        public string baskettax{ get; set; }
        public decimal basketallprice{ get; set; }
        public string basketno { get; set; }
        public int custid { get; set; }
    }
}