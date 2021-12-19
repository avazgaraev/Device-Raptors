using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class adminloginController : Controller
    {
        context c = new context();
        // GET: adminlogin
        public ActionResult Indexadmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Indexadmin(admin a)
        {
            var values = c.Admins.FirstOrDefault(x => x.adminname == a.adminname && x.adminpass == a.adminpass);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.adminname, false);
                Session["adminname"] = values.adminname.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Login", "Homeindex");  
            }
        }
    }
}