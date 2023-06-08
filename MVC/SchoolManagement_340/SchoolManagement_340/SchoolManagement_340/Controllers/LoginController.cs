using SchoolManagement_340.Models.CustomModel;
using SchoolManagement_340.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace SchoolManagement_340.Controllers
{
    public class LoginController : Controller
    {
        public IUserPanel_Interface userPanel;
        public LoginController(IUserPanel_Interface _userPanel)
        {
            userPanel = _userPanel;
        }
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(CustomSignIn data)
        {
            if (userPanel.AlreadyRegister(data) == true)
            {
                FormsAuthentication.SetAuthCookie(data.UserEmail, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Error"] = "Invalid Email/Password";
                return RedirectToAction("SignIn", "Login");
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(CustomSignUp data)
        {
            try
            {
                if (userPanel.RegisterUser(data) == true)
                {
                    return RedirectToAction("SignIn", "Login");
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult Forgot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Forgot(CustomSignUp data)
        {
            var Result = userPanel.IsEmailExists(data);
            if (Result != null)
            {
                WebMail.Send(Result.UserEmail, "Forgot Id Password", "<h3>Id Password For Login in School Management System<h3><br><br><h4>Email Address : " +
                    Result.UserEmail + "</h4><br><h4>Password : " +
                    Result.UserPassword + "</h4>", null, null, null, true, null, null, null, null, null, null);
                return RedirectToAction("SignIn", "Login");
            }
            else
            {
                TempData["Error"] = "Email Does not Register";
                return View();
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn");
        }
    }
}