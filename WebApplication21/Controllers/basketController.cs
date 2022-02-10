using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    [Authorize]
    public class basketController : Controller
    {
        // GET: basket
        context c = new context();
        public ActionResult Index()
        {
            var mail = (string)Session["customermail"];
            var id1 = c.Customers.Where(x => x.customermail == mail.ToString()).Select(y => y.customerid).FirstOrDefault();
            var values = c.baskets.Where(x => x.custid == id1).Where(x=>x.quantity>0).ToList();
            return View(values);
        }
        public PartialViewResult alsolike()
        {
            var values = c.Products.Take(4).ToList();
            return PartialView(values);
        }
        public ActionResult removebask(int id)
        {
            var mail = (string)Session["customermail"];
            var id1 = c.Customers.Where(x => x.customermail == mail.ToString()).Select(y => y.customerid).FirstOrDefault();
            var values = c.baskets.FirstOrDefault(x => x.custid == id1);
            id = values.prodid;
            var ctg = c.baskets.FirstOrDefault(x => x.prodid == id);
            c.baskets.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("index", "basket");
        }
        public ActionResult addbasket(basket s, int id)
        {
            var mail = (string)Session["customermail"];
            var id1 = c.Customers.Where(x => x.customermail == mail.ToString()).Select(y => y.customerid).FirstOrDefault();
            var value = c.Customers.FirstOrDefault(x => x.customerid == id1);
            var values = c.baskets.Where(x => x.custid == id1).ToList().FirstOrDefault(x=>x.prodid ==id);

            if (values is null)
            {
                s.quantity = s.quantity + 1;
                s.custid = value.customerid;
                s.prodid = id;
                s.price = c.Products.Where(x => x.productsid == id).ToList().Select(y => Convert.ToDecimal(y.productndprice)).FirstOrDefault();
                Random rnd = new Random();
                string[] ch = { "A", "C", "F", "V" };
                int k1, k2, k3;
                k1 = rnd.Next(0, 4);
                k2 = rnd.Next(0, 4);
                k3 = rnd.Next(0, 4);

                int s1, s2, s3;
                s1 = rnd.Next(100, 1000);
                s2 = rnd.Next(10, 100);
                s3 = rnd.Next(10, 100);

                string kod = s1.ToString() + ch[k1] + s2.ToString() + ch[k2] + s3.ToString() + ch[k3];
                s.basketno = kod;
                s.basketallprice = (s.quantity * s.price);
                s.prodimg = c.Products.Where(x => x.productsid == id).ToList().Select(y => y.productimg).FirstOrDefault();
                s.prodname = c.Products.Where(x => x.productsid == id).ToList().Select(y => y.productsname).FirstOrDefault();
                s.subtotoal = s.basketallprice;
                c.baskets.Add(s);
            }
            else if (values.prodid ==id)
            {
                values.quantity = values.quantity + 1;
                values.subtotoal = values.quantity * values.price;
                values.basketallprice = values.subtotoal ;
            }
          

            
            c.SaveChanges();
            return RedirectToAction("Index", "basket");
        }
        public PartialViewResult basketresult()
        {
            var mail = (string)Session["customermail"];
            var id1 = c.Customers.Where(x => x.customermail == mail.ToString()).Select(y => y.customerid).FirstOrDefault();
            var value = c.baskets.Where(x => x.custid == id1).ToList();
            return PartialView(value);
        }
        public ActionResult basketcheck()
        {

            var mail = (string)Session["customermail"];
            var id1 = c.Customers.Where(x => x.customermail == mail.ToString()).Select(y => y.customerid).FirstOrDefault();
            var values = c.baskets.Where(x => x.custid == id1).ToList();
            return View(values);
        }
    }
}