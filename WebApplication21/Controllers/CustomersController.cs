using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class CustomersController : Controller
    {
        context c = new context();
        public ActionResult Indexcus()
        {
                
            var all = c.Customers.Where(x=> x.available ==true).ToList();
            return View(all);
        }
        public ActionResult addcus()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addcus(customer d)
        {
            d.available = true;
            c.Customers.Add(d);
            c.SaveChanges();
            return RedirectToAction("Indexcus");
        }
        public ActionResult cusdel(int id)
        {
            var cuss = c.Customers.Find(id);
            cuss.available = false;
            c.SaveChanges();
            return RedirectToAction("Indexcus");
        }
        public ActionResult cusupdatepage(int id) 
        {
            var cusall = c.Customers.Find(id);
            return View("cusupdatepage", cusall);
        }
        public ActionResult cusupdate(customer d)
        {
            var cusall = c.Customers.Find(d.customerid);
            cusall.customername = d.customername;
            cusall.customersurname = d.customersurname;
            cusall.customermail = d.customermail;
            cusall.customercity = d.customercity;
            cusall.customeraddress = d.customeraddress;
            c.SaveChanges();
            return RedirectToAction("Indexcus");
        }
        public ActionResult cussales(int id)
        {
            var cusde = c.Salemoves.Where(x => x.customer.customerid == id).ToList();
            var cs = c.Customers.Where(x => x.customerid == id).Select(y => y.customername + " " + y.customersurname).FirstOrDefault();
            ViewBag.cari = cs;
            return View(cusde);
        }
    }
}