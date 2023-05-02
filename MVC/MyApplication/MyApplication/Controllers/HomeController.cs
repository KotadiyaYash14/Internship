using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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
        public ActionResult Services()
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
        public ActionResult Contact()
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
        [HttpPost]
        public ActionResult Contact(User User)
        {
            try
            {
                User.user_list.Add(User);
                return RedirectToAction("UserDetails");
            }
            catch (Exception e)
            {
                ViewBag.error = e;
                return View();
            }
        }
        public ActionResult UserDetails()
        {
            try {
                return View(MyApplication.Models.User.user_list);
            }
            catch (Exception e)
            {
                ViewBag.error = e;
                return View();
            }
        }

    }
}
