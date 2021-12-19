using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using WebApplication21.Models;
using System.Web.Security;
using PagedList;

namespace WebApplication21.Controllers
{
    public class HomeindexController : Controller
    {
        // GET: Homeindex
        context c = new context();

        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Shop(int pages=1)
        {
            var prods = from x in c.Products.Where(x => x.productavailable == true) select x;
           
            return View(prods.ToList().ToPagedList(pages, 4));

        }
        public ActionResult Register()
        {
            
            return View();
        }

        public PartialViewResult partialcat()
        {
            var values = c.Categories.ToList();
            return PartialView(values);
        }

        [HttpPost]
        public ActionResult Register(customer b)
        {
            c.Customers.Add(b);
            b.available = true;
            c.SaveChanges();
            return RedirectToAction("Login");
        }

        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login( customer b)
        {
            var values = c.Customers.FirstOrDefault(x => x.customermail == b.customermail && x.customerpass == b.customerpass);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.customermail, false);
                Session["customermail"] = values.customermail.ToString();
                return RedirectToAction("Index", "customerpanel");
            }
            else
            {
                return View();
            }
        }
        public ActionResult logout()
        {
            HttpCookie cookie = new HttpCookie("users");
            cookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }
        public PartialViewResult parslider()
        {
            var values = c.sliders.ToList();
            return PartialView(values);
        }
        public PartialViewResult parcat()
        {
            var values = c.Categories.ToList();
            return PartialView(values);
        }

        public PartialViewResult parcat1()
        {
            var values = c.Categories.ToList();
            return PartialView(values);
        
        }
        public PartialViewResult parcat2()
        {
            var values = c.Categories.ToList();
            return PartialView(values);
        }
        public ActionResult prodcat(int id)
        {
            prodcategory cs = new prodcategory();
            var values = c.Products.FirstOrDefault(x=>x.Categoryid==id);
            cs.pros = c.Products.Where(x => x.productsid == values.productsid).ToList();
            cs.categories = c.Categories.Where(y => y.CategoryID == values.Categoryid).ToList();
            return View(cs);
        }

        public PartialViewResult prodcount()
        {
            var values = c.Products.FirstOrDefault();
            return PartialView(values);
        }
    }
}

