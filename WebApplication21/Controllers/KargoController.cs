using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class KargoController : Controller
    {
        context c = new context();
        // GET: Kargo
        public ActionResult Index(string p)
        {
            var kargolar = from x in c.kargos select x;
            if (!string.IsNullOrEmpty(p))
            {
                kargolar = kargolar.Where(e => e.kargono.Contains(p));

            }
            return View(kargolar.ToList());
        }

        public ActionResult addkargo()
        {
            Random rnd = new Random();
            string[] ch = {"A", "C", "F", "V"};
            int k1, k2, k3;
            k1 = rnd.Next(0, 4);
            k2 = rnd.Next(0, 4);
            k3 = rnd.Next(0, 4);

            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 100);
            s3 = rnd.Next(10, 100);

            string kod = s1.ToString() + ch[k1] + s2.ToString() + ch[k2] + s3.ToString() + ch[k3];
            ViewBag.value = kod;
            return View();
        }
        [HttpPost]
        public ActionResult addkargo(kargo k)
        {
            c.kargos.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index", "Kargo");
        }

        public ActionResult kargostatus(string id)
        {
            var values = c.kargofollows.Where(x => x.kargono == id).ToList();
            return View(values);
        }

        public ActionResult cuskargodetail(string id)
        {
            var values = c.kargofollows.Where(x => x.kargono == id).ToList();
            return View(values);
        }
    }
}