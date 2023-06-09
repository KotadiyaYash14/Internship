using SchoolManagement_340.Helper.SessionHelper;
using SchoolManagement_340.Helper.SignUpHelper;
using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using SchoolManagement_340.Repository.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement_340.Controllers
{
    //[Authorize]
    [Validate]
    public class HomeController : Controller
    {
        SchoolManagement_yk_340Entities db = new SchoolManagement_yk_340Entities();
        SignUpHelper suh = new SignUpHelper();
        public IUserPanel_Interface userPanel;
        public HomeController(IUserPanel_Interface _userPanel)
        {
            userPanel = _userPanel;
        }
        public ActionResult Index()
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
        public ActionResult About()
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
        public ActionResult Contact()
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
        public ActionResult Services()
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
        public ActionResult UserProfile()
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
        public ActionResult EditProfile()
        {
            try
            {
                if(Session["UserEmail"] != null)
                {
                    User User = userPanel.GetUserNameFromEmailForSession(Session["UserEmail"].ToString());
                    CustomSignUp cs = suh.ConvertSignUpToCustomSignUp(User);
                    return View(cs);
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult EditProfile(CustomSignUp data)
        {
            string FileName = Path.GetFileNameWithoutExtension(data.ImagePath.FileName);

            string FileExtension = Path.GetExtension(data.ImagePath.FileName);

            FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

            data.Image = Server.MapPath(("~/Images/") + FileName);

            Session["Image"] = FileName;
            SessionData.Image = FileName;

            data.ImagePath.SaveAs(data.Image);

            ImageTable Img = new ImageTable()
            {
                IamgeId = data.IamgeId,
                //ImageTitle = data.ImageTitle,
                Image = FileName,
                UserId = data.UserId
            };
            db.ImageTable.Add(Img);
            db.SaveChanges();

            return RedirectToAction("UserProfile");
        }
    }
}