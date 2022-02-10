using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class altbannerController : Controller
    {
        // GET: altbanner
        context c = new context();
        public ActionResult Index()
        {
            var values = c.altbanners.ToList();
            return View(values);
        }
        public ActionResult addslider()
        {

            return View();
        }
        [HttpPost]
        public ActionResult addslider(altbanner sr)
        {


            c.altbanners.Add(sr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult delslider(int id)
        {
            var ctg = c.altbanners.Find(id);
            c.altbanners.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("Index", "altbanner");
        }
        public ActionResult updslider(int id)
        {
            var ctgu = c.altbanners.Find(id);
            return View("updslider", ctgu);
        }

        public ActionResult updslidere(altbanner k)
        {
            var kgtu = c.altbanners.Find(k.sliderid);
            kgtu.sliderheader = k.sliderheader;
            kgtu.sliderimg = k.sliderimg;
            kgtu.slidertoprod = k.slidertoprod;
            c.SaveChanges();
            return RedirectToAction("Index", "altbanner");
        }
    }
}