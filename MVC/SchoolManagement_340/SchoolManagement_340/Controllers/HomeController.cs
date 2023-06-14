using SchoolManagement_340.Helper.SessionHelper;
using SchoolManagement_340.Helper.SignUpHelper;
using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using SchoolManagement_340.Repository.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement_340.Controllers
{
    //[Authorize]
    //[Validate]
    public class HomeController : Controller
    {
        SchoolManagement_yk_340Entities db = new SchoolManagement_yk_340Entities();
        SignUpHelper suh = new SignUpHelper();
        CountryHelper ch = new CountryHelper();
        public IUserPanel_Interface userPanel;
        public HomeController(IUserPanel_Interface _userPanel)
        {
            userPanel = _userPanel;
        }
        public async Task<ActionResult> Index()
        {
            try
            {
                IEnumerable<Country> Country = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51562/api/");
                    var responseTask = await client.GetAsync("Country");
                    var result = responseTask.EnsureSuccessStatusCode();
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsAsync<IList<Country>>();
                        Country = readTask;
                    }
                    else
                    {
                        Country = null;
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
                return View(Country);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<ActionResult> AddEditCountry(int id)
        {
            try
            {
                if (id == 0)
                {
                    return View();
                }
                else
                {
                    Country country = null;
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:51562/api/");
                        var postTask = await client.GetAsync("Country?id=" + id.ToString());

                        var result = postTask.EnsureSuccessStatusCode();
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = await result.Content.ReadAsAsync<Country>();
                            country = readTask;
                        }
                        else
                        {
                            country = null;
                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        }
                        CustomCountry custom = ch.ConvertCountryToCustomCountry(country);
                        return View(custom);
                    }
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddEditCountry(CustomCountry data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51562/api/");
                    var postTask = await client.PostAsJsonAsync<CustomCountry>("Country", data);

                    var result = postTask.EnsureSuccessStatusCode();
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                    return View(data);
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }
        public async Task<ActionResult> DeleteCountry(int? id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51562/api/");
                    var deleteTask = await client.DeleteAsync("Country?id=" + id.ToString());

                    var result = deleteTask.EnsureSuccessStatusCode();
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
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
                if (Session["UserEmail"] != null)
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