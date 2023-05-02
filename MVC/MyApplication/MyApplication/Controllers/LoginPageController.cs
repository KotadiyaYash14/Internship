using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApplication.Controllers
{
    public class LoginPageController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            try
            { 
                return View();
            }
            catch (Exception e)
            {
                ViewBag.error = e;
                return View();
            }

        }
    }
}