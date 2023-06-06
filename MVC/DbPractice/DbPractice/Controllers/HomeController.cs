using DbPractice.Models.Context;
using DbPractice.Models.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DbPractice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<country> countries = new List<country>();
            using(yk327Entities db = new yk327Entities())
            {
                countries = db.country.ToList();
            }
            return View(countries);
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public ActionResult About(CountryModel data)
        {
            using (yk327Entities db = new yk327Entities())
            {
                db.country.Add(new country
                {
                    CountryName = data.CountryName
                });
                db.SaveChanges();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Contact(int id)
        {
            using(yk327Entities db = new yk327Entities())
            {
                db.country.Where(x => x.CountryId == id).FirstOrDefault();

                //db.country.Find()
            }
            return View();
        }
    }
}