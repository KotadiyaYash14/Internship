using StudentRegistration.Models.Context;
using StudentRegistration.Models.CustomeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentRegistration.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Signin()
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
        public ActionResult Signin(CustomeSignUp data)
        {
            using (yk327Entities1 db = new yk327Entities1())
            {
                myuser mu = new myuser()
                {
                    UserPassword = data.UserPassword,
                    UserEmail = data.UserEmail
                };
                if (db.myusers.Any(x => x.UserEmail == data.UserEmail && x.UserPassword == data.UserPassword))
                {
                    FormsAuthentication.SetAuthCookie(mu.UserEmail, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Error"] = "Invalid Email/Password";
                    return RedirectToAction("Signin", "Login");
                }
            }
        }
        public ActionResult SignUp()
        {
            try
            {
                using (yk327Entities1 db = new yk327Entities1())
                {
                    ViewBag.RoleList = new SelectList(db.roles.ToList(), "roleid", "rolename");
                }
                return View();
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }
        [HttpPost]
        public ActionResult SignUp(CustomeSignUp data)
        {
            using (yk327Entities1 db = new yk327Entities1())
            {
                myuser mu = new myuser()
                {
                    UserFirstName = data.UserFirstName,
                    UserLastName = data.UserLastName,
                    UserEmail = data.UserEmail,
                    UserPassword = data.UserPassword,
                    UserRole = data.UserRole
                };
                db.myusers.Add(mu);
                db.SaveChanges();
            }
            return RedirectToAction("Signin");
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
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Signin");
        }
    }
}