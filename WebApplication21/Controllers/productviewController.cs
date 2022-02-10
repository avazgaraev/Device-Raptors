using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class productviewController : Controller
    {
        // GET: productview
        context c = new context();
        public ActionResult Index(int id)
        {
            allproducts cs = new allproducts();
            cs.d1 = c.Products.Where(x => x.productsid == id).ToList();
            cs.d2 = c.prodcolors.Where(x => x.productid == id).ToList();
            cs.d3 = c.prodimgs.Where(x => x.productid == id).ToList();
            cs.d4 = c.prodsizes.Where(x => x.productid == id).ToList();
            cs.d5 = c.Details.Where(x => x.productid == id).ToList();
            return View(cs);
        }
        public PartialViewResult related()
        {
            return PartialView();
        }
    }
}