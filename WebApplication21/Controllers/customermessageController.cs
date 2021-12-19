using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class customermessageController : Controller
    {
        context c = new context();
        // GET: customermessage
        public ActionResult Index()
        {
            var values = c.messages.ToList();
            return View(values);
        }
        public ActionResult newmessagepg()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult newmessagepg()
        //{
        //    return View();
        //}
    }
}