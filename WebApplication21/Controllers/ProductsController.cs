using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;
using PagedList;
using PagedList.Mvc;

namespace WebApplication21.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        context c = new context();
        public ActionResult Indexmain(string p, int pages = 1)
        {
            var prods = from x in c.Products select x;
            if (!string.IsNullOrEmpty(p))
            {
                prods =prods.Where(e => e.productsname.Contains(p));
               
            }
            return View(prods.Where(x => x.productavailable == true).ToList().ToPagedList(pages, 30));
        }
        public ActionResult productadd()
        {
            List<SelectListItem> listed= (from x in c.Categories.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.CategoryName,
                                           Value = x.CategoryID.ToString()
                                       }).ToList();
            ViewBag.listim = listed; 
            return View();
        }
        [HttpPost]
        public ActionResult productadd(products p, HttpPostedFileBase file)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/storage/products"), _FileName);
                    file.SaveAs(_path);
                }
                return RedirectToAction("Indexmain");
            }
            catch
            {
                return View();
            }


            //if (Request.Files.Count > 0)
            //{
            //    //string end = Path.GetExtension(Request.Files[0].FileName);
            //    //string filename = Path.GetFileName(Request.Files[0].FileName);
            //    //var extention = Path.GetExtension(Request.Files[0].FileName);

            //    //var randomName = string.Format($"{DateTime.Now.Ticks}{extention}");
            //    //p.productimg = "~/Content/storage/products/" + randomName;
            //    //var road = "~/Content/storage/products/" + randomName;
            //    //Request.Files[0].SaveAs(Server.MapPath(road));

            //    string Photoname = "Photo" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(Request.Files[0].FileName);
            //    Request.Files[0].SaveAs(Server.MapPath("~/Content/storage/products/" + Photoname));
            //    p.productimg = Photoname;
            //}
            //c.Products.Add(p);
            //c.SaveChanges();
            //return RedirectToAction("Indexmain");
        }
        public ActionResult proddel(int id)
        {
            var prd = c.Products.Find(id);
            prd.productavailable = false;
            c.SaveChanges();
            return RedirectToAction("Indexmain");

        }
        public ActionResult produpdpage(int id)
        {
            List<SelectListItem> listed = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.listim = listed;
            var produpd = c.Products.Find(id);
            return View("produpdpage", produpd);
        }
        public ActionResult produpd(products p)
        {
            var prd = c.Products.Find(p.productsid);
            prd.productstprice = p.productstprice;
            prd.productndprice = p.productndprice;
            prd.productsname = p.productsname;
            prd.Categoryid = p.Categoryid;
            prd.productstock = p.productstock;
            prd.productmarka = p.productmarka;
            prd.productimg = p.productimg;
            prd.productavailable = p.productavailable;
            c.SaveChanges();
            return RedirectToAction("Indexmain");
        }
        public ActionResult printac()
        {
            var values = c.Products.ToList();
            return View(values);
        }
        
        public ActionResult makesale( int id)
        {
            var value1 = c.Products.Find(id);
            ViewBag.dgr1 = value1.productsid;
            ViewBag.dgr2 = value1.productstprice;
            return View();
        }
        [HttpPost]
        public ActionResult makesale(salemove s)
        {

            s.saledate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Salemoves.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index", "Sales");
        }
    }
}