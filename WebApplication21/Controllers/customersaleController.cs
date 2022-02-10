using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;
using PayPal.Api;

namespace WebApplication21.Controllers
{
    [Authorize]
    public class customersaleController : Controller
    {
        context c = new context();
        // GET: customersale
        public ActionResult Index()
        {
            var mail = (string)Session["customermail"];
            var id = c.Customers.Where(x => x.customermail == mail.ToString()).Select(y => y.customerid).FirstOrDefault();
            var values = c.Salemoves.Where(x => x.customerid == id).ToList();
            return View(values);
        }   
        public PartialViewResult partialsale()
        {
            var mail = (string)Session["customermail"];
            var id = c.Customers.Where(x => x.customermail == mail.ToString()).Select(y => y.customerid).FirstOrDefault();
            var values = c.Customers.Where(x => x.customerid == id).ToList();
            return PartialView(values);
        }

        public ActionResult addsale(salemove s)
        {
            var mail = (string)Session["customermail"];
            var id1 = c.Customers.Where(x => x.customermail == mail.ToString()).Select(y => y.customerid).FirstOrDefault();
            var value = c.Customers.FirstOrDefault(x=>x.customerid==id1);
            s.customerid = value.customerid;
            var cha = c.baskets.Where(x => x.custid == value.customerid).ToList();
            //s.productsid = cha.Select(x=>x.prodid);
            
            //s.salecount = c.Salemoves.Where(x=>x.productsid==id).FirstOrDefault().salecount;
            //var id2 = c.Salemoves.Where(x => x.productsid == id).Select(y => y.saleno).FirstOrDefault();
            //s.salecount = c.Salemoves.Where(x => x.customerid == value.customerid).ToList().Select(y => y.salecount).FirstOrDefault();

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
            s.saleno = kod;
            foreach (var item in cha)
            {
                s.productsid = item.prodid;
                s.saledate = DateTime.Parse(DateTime.Now.ToShortDateString());
                //s.saleallprice = Convert.ToInt32(Convert.ToInt32(s.salecount) * Convert.ToInt32(s.saleprice));
                s.saleallprice = item.basketallprice;
                s.saleprice = item.price;
                s.salecount = item.quantity;
                c.Salemoves.Add(s);
            c.SaveChanges();
            }
           
            //var saleprod = c.Products.Find(id);
            //s.salecount = ;
            ////s.salecount = c.Salemoves.Where(x => x.saleno == kod).ToList().FirstOrDefault(saleprod.productndprice);
            ////s.saleprice= c.Salemoves.Where(x => x.productsid == id).FirstOrDefault().saleprice;
            ////s.saleprice = c.Salemoves.Where(x => x.productsid == id).ToList().Select(y => y.saleprice).FirstOrDefault();
            ////s.saleprice = c.Salemoves.Find(value).saleprice;
            ////s.saleprice = c.Salemoves.Where(x => x.saleno == kod).ToList().Select(y => y.saleprice).FirstOrDefault();
            //s.saleprice = c.Products.Where(x => x.productsid == id).ToList().Select(y=> Convert.ToInt32(y.productndprice)).FirstOrDefault();
            return RedirectToAction("Index", "customersale");
        }
        public ActionResult saledetail(string id)
        {
            var values = c.baskets.Where(x => x.basketno == id).ToList();
            return View(values);
        }
    }
}