using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using StudentRegistration.Models;

namespace StudentRegistration.Controllers
{
   
    public class LoginController : Controller
    {
        // GET: Login
        
        public ActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error50");
            }
        }

        [HttpPost]
        public ActionResult Login(SchoolUserLogin userLogin)
        {
            try
            {
                UserAccount LoginInfo = new UserAccount();
                SchoolUserLogin User = LoginInfo.UserLogin(userLogin);
                if (User != null)
                {
                    FormsAuthentication.SetAuthCookie(User.FName + " " + User.LName, false);
                    return RedirectToAction("ShowStudentdata", "Home");
                }
                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error50");
            }
        }
        
        public ActionResult Register()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error50");
            }
        }
        [HttpPost]
        public ActionResult Register(SchoolUserLogin newUser)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UserAccount NewUser = new UserAccount();
                    int useradd = NewUser.UserRegister(newUser);

                    if (useradd == 1)
                    {
                        return RedirectToAction("Login", "Login");
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error50");
            }
        }
        public ActionResult Logout()
        {
            try
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error50");
            }
        }

    }
}