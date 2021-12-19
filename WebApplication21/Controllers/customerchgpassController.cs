using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class customerchgpassController : Controller
    {
        context c = new context();
        // GET: customerchgpass
        public ActionResult Index()
        {
            var mail = (string)Session["customermail"];
            var values = c.Customers.Where(x => x.customermail == mail).ToList();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(customer p)
        {
            var mail = (string)Session["customermail"];
            var values = c.Customers.FirstOrDefault(x => x.customermail == mail);
            values.customerpass = p.customerpass;
            c.SaveChanges();
            return RedirectToAction("Index", "customerpanel");
        }
    }
}