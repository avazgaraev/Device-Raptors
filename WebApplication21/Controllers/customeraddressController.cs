using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class customeraddressController : Controller
    {
        context c = new context();
        // GET: customeraddress
        public ActionResult Index()
        {
            var mail = (string)Session["customermail"];
            var values = c.Customers.Where(x => x.customermail == mail).ToList();
            return View(values);
        }
        public ActionResult addaddress()
        {
            var mail = (string)Session["customermail"];
            var values = c.Customers.Where(x => x.customermail == mail).ToList();
            return View(values);
        }
        [HttpPost]
        public ActionResult addaddress(customer b)
        {
            var mail = (string)Session["customermail"];
            var values = c.Customers.FirstOrDefault(x => x.customermail == mail);
            c.Customers.Add(values);
            c.SaveChanges();
            return RedirectToAction("Index", "customeraddress");
        }
        [HttpPost]
        public ActionResult newsale(salemove s)
        {
            s.saledate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Salemoves.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}