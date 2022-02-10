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
        public PartialViewResult banpartial()
        {
            var values = c.altbanners.ToList();
            return PartialView(values);
        }
        public PartialViewResult latest()
        {
            var baselineDate = DateTime.Now.AddDays(-3);
            return PartialView(c.Products.Where(x => x.prodcomedate > baselineDate).OrderByDescending(x => x.prodcomedate).Take(4).ToList());
           
        }
        public ActionResult Shop(int pages=1)
        {
            var prods = from x in c.Products.Where(x => x.productavailable == true) select x;
            return View(prods.ToList().ToPagedList(pages, 12));

        }
        public ActionResult Register()
        {
            
            return View();
        }

        public PartialViewResult partialcat()
        {
            var values = c.subcategories.ToList();
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
        public PartialViewResult subcatpart()
        {
            var values = c.subcategories.ToList();
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



        public PartialViewResult parcat11()
        {
            //var values = c.Categories.ToList();
            //catsubcat cs = new catsubcat();
            

            //cs.categories = c.Categories.ToList();
            //int a;
            //foreach (var item in cs.categories)
            //{
            //    a = item.CategoryID;
            //    cs.sub = c.subcategories.Where(x=>x.CategoryId==a).ToList();
            //}


            var aa = c.Categories.Include("Subcategories").ToList();
            return PartialView(aa);

        }




        public PartialViewResult subcat()
        {
            var values = c.subcategories.Where(x => x.CategoryId == x.Category.CategoryID).ToList();
            return PartialView(values);
        } 
        public PartialViewResult parcat2()
        {
            var values = c.subcategories.ToList();
            return PartialView(values);
        }
        public ActionResult prodcat(int id, int pages=1)
        {
            //catsubcat cs = new catsubcat();
            //var values = c.subcategories.Where(x => x.CategoryId== id).ToList();
            //cs.sub = values;
            //if (cs.pros == false)
            //{

            //}
            //cs.categories = c.Categories.Where(y => y.CategoryID == id).ToList();

            var prods = from x in c.Products.Where(x => x.productavailable == true).Where(x=>x.Categoryid==id) select x;
            return View(prods.ToList().ToPagedList(pages, 12));
        }

        public PartialViewResult prodcount()
        {
            var values = c.Products.FirstOrDefault();
            return PartialView(values);
        }

        public ActionResult prodsearch(string b,int pages=1)
        {
            var prods = from x in c.Products select x;
            if (!string.IsNullOrEmpty(b))
            {
                prods = prods.Where(e => e.productsname.Contains(b));
            }
            return View(prods.ToList().ToPagedList(pages, 6));
        }
        public ActionResult contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult contact(contact d)
        {
            d.contactdate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.contacts.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index", "Homeindex");
        }
        public PartialViewResult sliderright()
        {
            var values = c.sliderrights.ToList();
            return PartialView(values);
        }

        public PartialViewResult bestseller()
        {
            //var systemUsers = c.Salemoves
            //            .Include(s => s.salemove)
            //            .Select(s => new prodsale
            //            { //<--HERE
            //                productimg = ,
            //                Email = s.Email,
            //                Image = s.Image,
            //                UpdateDate = s.UpdateDate,
            //                UpdatedBy = s.UpdatedBy,
            //                Id = s.Id
            //            });
            //return View(systemUsers.ToList());


            //var values = c.Salemoves.OrderBy(d => d.productsid).GroupBy(d => d.products.productsname).SelectMany(g => g).ToList();


            //for (int i = 0; i < c.Salemoves.Count(); i++)
            //{

            //}
            //string[] selectedColumns = new[] { "Column1", "Column2" };

            //List dt = new List(c.Salemoves.ToList);

            //var newList = c.Salemoves.OrderByDescending(x => x.productsid)
            //      .ThenBy(x => x.products)
            //      .ToList();
            var values = c.Products.OrderByDescending(x => x.productstock).Take(4).ToList();

            //var values2 = from x in c.Salemoves
            //              group x by x.products.productsname into g
            //              select new prodsale
            //              {
            //                  productimg = g.Select(x=>x.products.productimg),
            //                  Count = g.Count()
            //              };
            //var dataTable = newList.("saleid = 6").CopyToDataTable().DefaultView.ToTable(false, "saleid");
            return PartialView(values);

        }
        public ActionResult aboutus()
        {
            return View();
        }
        public ActionResult terms()
        {
            return View();
        }

        public ActionResult shipping()
        {
            return View();
        }
        public ActionResult privacy()
        {
            return View();
        }
       
    }
}

