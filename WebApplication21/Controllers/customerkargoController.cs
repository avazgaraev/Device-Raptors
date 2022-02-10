using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    [Authorize]
    public class customerkargoController : Controller
    {
        context c = new context();
        // GET: customerkargo
        public ActionResult Index(string p)
        {
            var kargolar = from x in c.kargos select x;
            kargolar = kargolar.Where(e => e.kargono.Contains(p));
            return View(kargolar.ToList());
        }
        public ActionResult cuskargodetail(string id)
        {
            var values = c.Salemoves.FirstOrDefault(x => x.saleno == id);
            return View(values);
        }
        public PartialViewResult partialname()
        {
            var mail = (string)Session["customermail"];
            var values = c.Customers.Where(x => x.customermail == mail).ToList();
            return PartialView(values);
        }

        public PartialViewResult partialprod()
        {
            var mail = (string)Session["customermail"];
            var id = c.Customers.Where(x => x.customermail == mail.ToString()).Select(y => y.customerid).FirstOrDefault();
            var values = c.Salemoves.FirstOrDefault(x => x.customerid == id);
            return PartialView(values);
        }

        public PartialViewResult partialcus()
        {
            var mail = (string)Session["customermail"];
            var values = c.Customers.FirstOrDefault(x => x.customermail == mail);
            return PartialView(values);
        }


        public ActionResult kargodel(string id)
        {
            var values = c.kargos.FirstOrDefault(x => x.kargono == id);
            values.available = false;
            var values1 = c.Salemoves.FirstOrDefault(x => x.kargono == id);
            c.Salemoves.Remove(values1);
            c.SaveChanges();
            return RedirectToAction("Index", "customersale");
        }

        public PartialViewResult partialsale()
        {
            var mail = (string)Session["customermail"];
            var id = c.Customers.Where(x => x.customermail == mail.ToString()).Select(y => y.customerid).FirstOrDefault();
            var values = c.Salemoves.Where(x => x.customerid == id).ToList();
            return PartialView(values);
        }

    }
}