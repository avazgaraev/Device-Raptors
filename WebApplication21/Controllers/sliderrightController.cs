using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class sliderrightController : Controller
    {
        // GET: sliderright
        context c = new context();
        public ActionResult Index()
        {
            var values= c.sliderrights.ToList();
            return View(values);
        }
        public ActionResult addslider()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult addslider(sliderright sr)
        {


            c.sliderrights.Add(sr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult delslider(int id)
        {
            var ctg = c.sliderrights.Find(id);
            c.sliderrights.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("Index", "sliderright");
        }
        public ActionResult updslider(int id)
        {
            var ctgu = c.sliderrights.Find(id);
            return View("updslider", ctgu);
        }

        public ActionResult updslidere(sliderright k)
        {
            var kgtu = c.sliderrights.Find(k.sliderid);
            kgtu.sliderheader = k.sliderheader;
            kgtu.sliderimg = k.sliderimg;
            kgtu.slidertoprod = k.slidertoprod;
            c.SaveChanges();
            return RedirectToAction("Index", "sliderright");
        }
    }
}