using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class SalesController : Controller
    {
        context c = new context();
        public ActionResult Index()
        {
           
            var values = c.Salemoves.ToList();
            //var ctg = c.Customers.Find(id);
            //var ptg = c.sales.Find(id);
            return View(values);
        }
        public ActionResult newsale()
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.productsname,
                                               Value = x.productsid.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;
            List<SelectListItem> value2 = (from x in c.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.customername + " " + x.customersurname,
                                               Value = x.customerid.ToString()
                                           }).ToList();
            ViewBag.vl2 = value2;
            
            return View();
        }
        [HttpPost]
        public ActionResult newsale(salemove s)
        {
            s.saledate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Salemoves.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult updsalepage(int id)
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.productsname,
                                               Value = x.productsid.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;
            List<SelectListItem> value2 = (from x in c.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.customername + " " + x.customersurname,
                                               Value = x.customerid.ToString()
                                           }).ToList();
            ViewBag.vl2 = value2;
            
            var value = c.Salemoves.Find(id);
            return View("updsalepage", value);
        }
        public ActionResult saleupd(salemove p)
        {
            var slu = c.Salemoves.Find(p.saleid);
            slu.salecount = p.salecount;
            slu.productsid = p.productsid;
            slu.customerid= p.customerid;
            slu.saleprice = p.saleprice;
            slu.saleallprice = p.saleallprice;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult saledetail(int id)
        {
            var values = c.Salemoves.Where(x => x.saleid == id).ToList();
            return View(values);
        }
    }
}