using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class customerprofController : Controller
    {
        context c = new context();
        // GET: customerprof
        public ActionResult Index()
        {
            var mail = (string)Session["customermail"];
            var values = c.Customers.Where(x => x.customermail == mail).ToList();
            return View(values);
        }
        public ActionResult cusupd(customer p)
        {
            var mail = (string)Session["customermail"];
            var values = c.Customers.FirstOrDefault(x => x.customermail == mail);
            values.customername = p.customername;
            values.customersurname = p.customersurname;
            values.customermail = p.customermail;
            values.customercity = p.customercity;
            values.customeraddress = p.customeraddress;
            values.customerphone = p.customerphone;
            c.SaveChanges();
            return RedirectToAction("Index", "customerprof");
        }
    }
}