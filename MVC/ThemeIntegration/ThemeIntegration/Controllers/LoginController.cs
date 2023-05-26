using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThemeIntegration.Models;

namespace ThemeIntegration.Controllers
{
    public class LoginController : Controller
    {
        public static List<SignUp> users = new List<SignUp>();
        public ActionResult Signin()
        {
            try
            {
                return  View();
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }
        [HttpPost]
        public ActionResult Signin(SignIn data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = users.Where(x => x.Email == data.Email && x.Password == data.Password).FirstOrDefault();
                    if (user != null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Error = "Email/Password is Incorrect";
                        return View();
                    }
                }
                else
                {
                    return View(data);
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }
        public ActionResult SignUp()
        {
            try
            {
                return View();
            }
            catch (Exception Exce)
            {
                throw Exce;
            }

        }
        [HttpPost]
        public ActionResult SignUp(SignUp data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    users.Add(data);
                    return RedirectToAction("Signin");
                }
                else
                {
                    return View(data);
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }

        }
        public ActionResult Forgot()
        {
            try
            {
                return View();
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }
    }
}