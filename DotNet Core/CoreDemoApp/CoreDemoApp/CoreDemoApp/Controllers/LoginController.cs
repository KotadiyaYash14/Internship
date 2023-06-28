using CoreDemoApp.Common.Helpers;
using CoreDemoApp.Model.AppSetting;
using CoreDemoApp.Model.ViewModel.Token;
using CoreDemoApp.Model.ViewModel.UserPanel;
using CoreDemoApp.Services.JWTAuthentication;
using CoreDemoApp.Services.UserPanel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace CoreDemoApp.Controllers
{
    public class LoginController : Controller
    {
        #region Fields

        private IUserPanelServices userPanelServices;
        private readonly IJWTAuthenticationServices jWTAuthenticationServices;
        private readonly AppSetting appSetting;

        #endregion

        #region Constructor

        public LoginController(IUserPanelServices _userPanelServices, IJWTAuthenticationServices _jWTAuthenticationServices, IOptions<AppSetting> appSettings)
        {
            userPanelServices = _userPanelServices;
            jWTAuthenticationServices = _jWTAuthenticationServices;
            appSetting = appSettings.Value;
        }

        #endregion

        #region Methods

        /// <summary>
        ///  Login Method
        /// </summary>
        public IActionResult SignIn()
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

        /// <summary>
        /// Login Post Method
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> SignIn(SignIn data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userPanelServices.UserLogin(data);
                    if (user != null)
                    {
                        UserTokenModel objTokenData = new UserTokenModel();
                        objTokenData.EmailId = user.UserEmail;
                        objTokenData.UserId = user.UserId != null ? user.UserId : 0;
                        objTokenData.UserName = user.UserName;
                        AccessTokenModel objAccessTokenData = new AccessTokenModel();
                        objAccessTokenData = jWTAuthenticationServices.GenerateTokenModel(objTokenData, appSetting.JWT_Secret, appSetting.JWT_Validity_Mins);
                        string secretkey = appSetting.JWT_Secret;
                        int JWTTime = appSetting.JWT_Validity_Mins;
                        //string JWTToken = jWTAuthenticationServices.GenerateToken(user.UserEmail, user.UserId.ToString(), secretkey, JWTTime);
                        await userPanelServices.UpdateLoginToken(objAccessTokenData.Token, objAccessTokenData.UserId);
                        string JWTToken = objAccessTokenData.Token;
                        HttpContext.Session.SetString("_userToken", JWTToken);
                        HttpContext.Session.SetString("_username", user.UserName);
                        HttpContext.Session.SetString("_useremail", user.UserEmail);
                        HttpContext.Session.SetString("_userid", user.UserId.ToString());
                        var checkStoredSession = HttpContext.Session.GetString("_userToken");
                        TempData["Success"] = "Login Succesfull";
                        return RedirectToAction("DashBoard", "Home");
                    }
                    else
                    {
                        TempData["Error"] = "Invalid Email/Password";
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Register Method
        /// </summary>
        public IActionResult SignUp()
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

        /// <summary>
        /// Register Post Method
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SignUp(UserData userData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userPanelServices.RegisterUser(userData);
                    if (user == 1)
                    {
                        return RedirectToAction("SignIn", "Login");
                    }
                    else if (user == -1)
                    {
                        TempData["Error"] = "Email is Already Exists";
                        return View();
                    }
                    else
                    {
                        TempData["Error"] = "Something went wrong!";
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// LogOut Method
        /// </summary>
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            TempData["LogOut"] = "You are LogOut";
            return RedirectToAction("SignIn");
        }

        #endregion
    }
}
