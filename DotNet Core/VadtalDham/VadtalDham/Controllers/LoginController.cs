using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using VadtalDham.Model.AppSetting;
using VadtalDham.Model.SMTPSetting;
using VadtalDham.Model.Token;
using VadtalDham.Model.ViewModel.UserPanel;
using VadtalDham.Services.JWTAuthentication;
using VadtalDham.Services.UserPanel;

namespace VadtalDham.Controllers
{
    public class LoginController : Controller
    {
        #region Fields

        private IUserPanelServices userPanelServices;
        private readonly IJWTAuthenticationServices jWTAuthenticationServices;
        private readonly SMTPSetting _smtpSettings;
        private readonly AppSetting appSetting;

        #endregion

        #region Constructor

        public LoginController(IUserPanelServices _userPanelServices, IOptions<SMTPSetting> smtpSettings, IJWTAuthenticationServices _jWTAuthenticationServices, IOptions<AppSetting> appSettings)
        {
            userPanelServices = _userPanelServices;
            _smtpSettings = smtpSettings.Value;
            jWTAuthenticationServices = _jWTAuthenticationServices;
            appSetting = appSettings.Value;
        }

        #endregion

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
        ///  Login Post Method
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

                        // Generate Token
                        objAccessTokenData = jWTAuthenticationServices.GenerateTokenModel(objTokenData, appSetting.JWT_Secret, appSetting.JWT_Validity_Mins);

                        string secretkey = appSetting.JWT_Secret;
                        int JWTTime = appSetting.JWT_Validity_Mins;

                        // Update Token
                        await userPanelServices.UpdateLoginToken(objAccessTokenData.Token, objAccessTokenData.UserId);

                        string JWTToken = objAccessTokenData.Token;

                        HttpContext.Session.SetString("_userToken", JWTToken);
                        HttpContext.Session.SetString("_username", user.UserName);
                        HttpContext.Session.SetString("_useremail", user.UserEmail);
                        HttpContext.Session.SetString("_userid", user.UserId.ToString());
                        var checkStoredSession = HttpContext.Session.GetString("_userToken");

                        TempData["Success"] = "Login Succesfull";
                        return RedirectToAction("Index", "Product");
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
        /// LogOut Method
        /// </summary>
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn");
        }

        /// <summary>
        /// forgot password Method
        /// </summary>
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(Forgot user)
        {
            if (ModelState.IsValid)
            {
                Forgot ForgotDetails = await userPanelServices.GetUserDetailsByEmail(user);
                if (ForgotDetails != null)
                {
                    var email = new MimeMessage();
                    email.Sender = MailboxAddress.Parse(_smtpSettings.FromEmail);
                    email.To.Add(MailboxAddress.Parse(ForgotDetails.UserEmail));
                    email.Subject = "Forgot Id/Password Email";
                    var builder = new BodyBuilder();
                    Random rand = new Random();
                    int OTP = rand.Next(999999);
                    await userPanelServices.UpdateOTP(ForgotDetails.UserId, OTP);
                    builder.HtmlBody = $"<h2>UserName : {ForgotDetails.UserName} </h2><br> <h2>Email : {ForgotDetails.UserEmail} </h2><br>" +
                        $"<h2>OTP : {OTP}</h2><br> ";
                    email.Body = builder.ToMessageBody();
                    using var smtp = new SmtpClient();
                    smtp.Connect(_smtpSettings.EmailHostName, Convert.ToInt32(_smtpSettings.EmailPort), SecureSocketOptions.StartTls);
                    smtp.Authenticate(_smtpSettings.FromEmail, _smtpSettings.EmailAppPassword);
                    await smtp.SendAsync(email);
                    smtp.Disconnect(true);
                    TempData["Email"] = ForgotDetails.UserEmail;
                    return RedirectToAction("AddOTP");
                }
                else
                {
                    TempData["Error"] = "Email not register";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public IActionResult AddOTP()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOTP(OTPModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var OTPData = await userPanelServices.OTPVerification(data.OTP, TempData["Email"].ToString());
                    TempData.Keep("Email");
                    if (OTPData == 1)
                    {
                        return RedirectToAction("ChangePassword");
                    }
                    else
                    {
                        TempData["Error"] = "Invalid OTP";
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
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UpdatePassword data)
        {
            if (ModelState.IsValid)
            {
                var success = await userPanelServices.UpdatePassword(data.NewPassword, TempData["Email"].ToString());
                TempData.Keep("Email");
                if (success == 1)
                {
                    TempData["Update"] = "Password Updated Successfully";
                    return RedirectToAction("SignIn");
                }
                else
                {
                    return RedirectToAction("ChangePassword");
                }
            }
            else
            {
                return View(data);
            }
            
        }
    }
}
