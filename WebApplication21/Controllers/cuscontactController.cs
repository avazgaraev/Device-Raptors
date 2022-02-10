using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class cuscontactController : Controller
    {
        context c = new context();
        // GET: cuscontact
        public ActionResult Index()
        {
            var values = c.contacts.ToList();
            return View(values);
        }
    }
}