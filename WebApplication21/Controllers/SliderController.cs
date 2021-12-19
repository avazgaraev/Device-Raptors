using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class SliderController : Controller
    {
        context c = new context();
        // GET: Slider
        public ActionResult Index()
        {
            var values = c.sliders.ToList();
            return View(values);
        }

        public ActionResult addslider()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addslider(sliders s)
        {
            c.sliders.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index", "slider");
        }
        public ActionResult delslider(int id)
        {
            var ctg = c.sliders.Find(id);
            c.sliders.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("Index", "slider");
        }
        public ActionResult updslider(int id)
        {
            var ctgu = c.sliders.Find(id);
            return View("updslider", ctgu);
        }
       
        public ActionResult updslidere(sliders k)
        {
            var kgtu = c.sliders.Find(k.sliderid);
            kgtu.sliderheader = k.sliderheader;
            kgtu.sliderimg = k.sliderimg;
            kgtu.slidertoprod = k.slidertoprod;
            kgtu.sliderdiscabout = k.sliderdiscabout;
            c.SaveChanges();
            return RedirectToAction("Index", "slider");
        }
    }
}