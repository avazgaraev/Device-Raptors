using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class salekarg
    {
        public IEnumerable<salemove> sale { get; set; }
        public IEnumerable<kargo> karg { get; set; }
    }
}