using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class customerpanelController : Controller
    {
        // GET: customerpanel
        context c = new context();

        [Authorize]
        public ActionResult Index()
        {   
            var mail = (string)Session["customermail"];
            var values = c.Customers.Where(x => x.customermail == mail).ToList();
            return View(values);
        }

       
    }
}