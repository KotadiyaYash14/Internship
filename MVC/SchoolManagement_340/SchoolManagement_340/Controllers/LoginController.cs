using SchoolManagement_340.Helper.SessionHelper;
using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using SchoolManagement_340.Models.GlobalEnum;
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
            try
            {
                return View();
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult SignIn(CustomSignIn data)
        {
            try
            {
                if (userPanel.AlreadyRegister(data) == 0)
                {
                    User user = userPanel.GetUserNameFromEmailForSession(data.UserEmail);
                    FormsAuthentication.SetAuthCookie(data.UserEmail, false);

                    Session["UserFirstName"] = user.UserFirstName;
                    SessionData.UserFirstName = user.UserFirstName;

                    Session["UserLastName"] = user.UserLastName;
                    SessionData.UserLastName = user.UserLastName;

                    Session["UserEmail"] = user.UserEmail;
                    SessionData.UserEmail = user.UserEmail;

                    Session["UserRole"] = user.UserRole;
                    SessionData.UserRole = Enum.Parse(typeof(RoleType), user.UserRole.ToString()).ToString();

                    TempData["Success"] = "Login Successful";
                    return RedirectToAction("Index", "Home");
                }
                //else if (userPanel.AlreadyRegister(data) == 1)
                //{
                //    TempData["Error"] = "Invalid Password";
                //    return RedirectToAction("SignIn", "Login");
                //}
                //else if (userPanel.AlreadyRegister(data) == 2)
                //{
                //    TempData["Error"] = "Invalid Email";
                //    return RedirectToAction("SignIn", "Login");
                //}
                else
                {
                    TempData["Error"] = "Invalid Email/Password";
                    return RedirectToAction("SignIn", "Login");
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult SignUp()
        {
            try
            {
                return View();
            }
            catch
            {
                return View();
            }
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
            catch
            {
                return View();
            }
        }
        public ActionResult Forgot()
        {
            try
            {
                return View();
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Forgot(CustomSignUp data)
        {
            try
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
            catch
            {
                return View();
            }
        }
        public ActionResult LogOut()
        {
            try
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                return RedirectToAction("SignIn");
            }
            catch
            {
                return View();
            }
        }

    }
}