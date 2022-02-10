using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        context c = new context();
        public ActionResult Indexstat()
        {
            var val1 = c.Customers.Count().ToString();
            ViewBag.d1 = val1;

            var val2 = c.Products.Count().ToString();
            ViewBag.d2 = val2;

            var val4 = c.Categories.Count().ToString();
            ViewBag.d4 = val4;

            var val5 = c.Products.Sum(x => x.productstock).ToString();
            ViewBag.d5 = val5;

            var val6 = (from x in c.Products select x.productmarka).Distinct().Count().ToString();
            ViewBag.d6 = val6;

            var val8 = (from x in c.Products orderby x.productndprice descending select x.productsname).FirstOrDefault();
            ViewBag.d8 = val8;

            var val9 = (from x in c.Products orderby x.productndprice ascending select x.productsname).FirstOrDefault();
            ViewBag.d9 = val9;

            var val7 = c.Products.Count(x => x.productstock <= 20).ToString();
            ViewBag.d7 = val7;

            var val14 = c.Salemoves.Sum(x => x.saleallprice).ToString();
            ViewBag.d14 = val14;

            DateTime today = DateTime.Today;
            var val15 = c.Salemoves.Count(x => x.saledate==today).ToString();
            ViewBag.d15 = val15;

            var val16 = c.Salemoves.Where(x => x.saledate == today).Sum(y=> y.saleallprice).ToString();
            ViewBag.d16 = val16;

            var val12 = c.Products.GroupBy(x => x.productmarka).OrderByDescending(y => y.Count()).Select(y=> y.Key).FirstOrDefault();
            ViewBag.d12 = val12;

            var val13 = c.Products.Where(u=> u.productsid==(c.Salemoves.GroupBy(x => x.productsid).OrderByDescending(y => y.Count()).Select(y => y.Key).FirstOrDefault())).Select(k=>k.productsname).FirstOrDefault();
            ViewBag.d13 = val13;

            return View();
        }
        public ActionResult simpletables()
        {
            var values = (from x in c.Customers
                          group x by x.customercity into g
                          select new classgroup
                          {
                              city = g.Key,
                              all = g.Count()
                          });
            
            return View(values.ToList());
        }
        public PartialViewResult partial1()
        {
            var values2 = from x in c.Products
                          group x by x.Subcategory.SubcategoryName into g
                          select new classgroup2
                          {
                              subcategory = g.Key,
                              Count = g.Count()
        };
            return PartialView(values2.ToList());
        }
        public PartialViewResult partial2()
        {
            var values3 = c.Customers.ToList();
            return PartialView(values3);
        }
        public PartialViewResult partial3()
        {
            var values4 = c.Products.ToList();
            return PartialView(values4);
        }

        public PartialViewResult partial4()
        {
            var values5 = from x in c.Products
                          group x by x.productmarka into g
                          select new classgroup3
                          {
                              Brend = g.Key,
                              Count = g.Count()
                          };
            return PartialView(values5);
        }
        public PartialViewResult partial5()
        {
            var values = c.Categories.ToList();
            return PartialView(values);
        }
    }
}