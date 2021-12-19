using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class ProductdetController : Controller
    {
        // GET: Productdet
        context c = new context();
        public ActionResult Indexprod()
        {
            Class1 cs = new Class1();
            //var values = c.Products.ToList();
            cs.Deger1 = c.Products.Where(x => x.productsid == 1).ToList();
            cs.Deger2 = c.Details.Where(y => y.Deatilid == 1).ToList();
            return View(cs);
        }
    }
}