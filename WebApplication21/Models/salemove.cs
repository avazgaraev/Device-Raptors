using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class salemove
    {
        [Key]
        public int saleid{ get; set; }
        //product
        //customer
        public DateTime saledate{ get; set; }
        public int salecount{ get; set; }
        public int saleprice{ get; set; }
        public int saleallprice{ get; set; }

        public int productsid { get; set; }
        public virtual products products { get; set; }

        public int customerid { get; set; }
        public virtual customer customer{ get; set; }

        public string kargono { get; set; }
        public virtual kargo Kargo{ get; set; }

        public string saleno { get; set; }
    }
}