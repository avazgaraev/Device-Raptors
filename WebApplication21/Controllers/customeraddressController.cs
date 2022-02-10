using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    [Authorize]
    public class customeraddressController : Controller
    {
        context c = new context();
        // GET: customeraddress
        public ActionResult Index()
        {
            var mail = (string)Session["customermail"];
            var values = c.Customers.FirstOrDefault(x => x.customermail == mail);
            var issue = c.cusaddresses.Where(x => x.customerid == values.customerid).ToList();
            return View(issue);
        }
        public ActionResult addaddress()
        {
            var mail = (string)Session["customermail"];
            var values = c.Customers.Where(x => x.customermail == mail).ToList();
            return View(values);
        }
        [HttpPost]
        public ActionResult addaddress(cusaddress b)
        {
            var mail = (string)Session["customermail"];
            var values = c.Customers.FirstOrDefault(x => x.customermail == mail);
            b.customerid = values.customerid;
            c.cusaddresses.Add(b);
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
        public PartialViewResult partcus()
        {
            var mail = (string)Session["customermail"];
            var values = c.Customers.FirstOrDefault(x => x.customermail == mail);
            return PartialView(values);
        }

        public ActionResult editadd(int id)
        {
            var values = c.cusaddresses.Find(id);
            return View("editadd", values);
        }
        [HttpPost]
        public ActionResult editadd(cusaddress d)
        {
            var mail = (string)Session["customermail"];
            var values = c.Customers.FirstOrDefault(x => x.customermail == mail);
            var cusall = c.cusaddresses.Find(d.addressid);
            //d.addstate = c.cusaddresses.FirstOrDefault(x => x.customerid == values.customerid).addstate;
            //d.zipcode = c.cusaddresses.FirstOrDefault(x => x.customerid == values.customerid).zipcode;
            //d.address = c.cusaddresses.FirstOrDefault(x => x.customerid == values.customerid).address;
            //d.addcity = c.cusaddresses.FirstOrDefault(x => x.customerid == values.customerid).addcity;
             cusall.addstate= d.addstate;
            cusall.addcity=d.addcity ;
            cusall.address=d.address ;
            cusall.zipcode=d.zipcode ;

            c.SaveChanges();
            return RedirectToAction("Index", "customeraddress");
        }
        public ActionResult removeadd(int id)
        {
            var values = c.cusaddresses.Find(id);
            c.cusaddresses.Remove(values);
            c.SaveChanges();
            return RedirectToAction("Index", "customeraddress");
        }

    }
}