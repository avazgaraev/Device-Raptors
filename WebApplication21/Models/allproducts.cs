using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class allproducts
    {
        public IEnumerable<products> d1 { get; set; }
        public IEnumerable<prodcolor> d2{ get; set; }
        public IEnumerable<prodimg> d3{ get; set; }
        public IEnumerable<prodsize> d4{ get; set; }
        public IEnumerable<Detail> d5{ get; set; }
    }
}