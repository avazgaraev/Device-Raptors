using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;
using PagedList;
using PagedList.Mvc;


namespace WebApplication21.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        context c = new context();
        public ActionResult Index(string p,int pages=1)
        {
            var prods = from x in c.Categories select x;
            if (!string.IsNullOrEmpty(p))
            {
                prods = prods.Where(e => e.CategoryName.Contains(p));

            }
            return View(prods.ToList().ToPagedList(pages, 4));
        }
        public ActionResult categadd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult categadd(Category k)
        {
            c.Categories.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult categdelete(int id)
        {
            var ctg = c.Categories.Find(id);
            c.Categories.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult categupdatepage(int id)
        {
            var ctgu = c.Categories.Find(id);
            return View("categupdatepage", ctgu);
        }
        public ActionResult categupdate(Category k)
        {
            var kgtu = c.Categories.Find(k.CategoryID);
            kgtu.CategoryName = k.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}