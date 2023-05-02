using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistration.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error505()
        {
            return View();
        }
        public ActionResult Error50()
        {
            return View();
        }
    }
}