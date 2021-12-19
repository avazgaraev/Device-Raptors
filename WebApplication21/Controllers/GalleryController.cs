using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class GalleryController : Controller
    {
        context c = new context();
        public ActionResult Index()
        {
            var values = c.Products.ToList();
            return View(values);
        }

    }
}