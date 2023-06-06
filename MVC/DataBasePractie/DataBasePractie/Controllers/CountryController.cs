using DataBasePractie.Models.Context;
using DataBasePractie.Models.CustomeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBasePractie.Controllers
{
    public class CountryController : Controller
    {
        public ActionResult AllCountry()
        {
            try
            {
                List<country> Countries;
                using (yk327Entities db = new yk327Entities())
                {
                    Countries = db.country.ToList();
                }
                return View(Countries);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }
        public ActionResult AddCountry()
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
        public ActionResult AddCountry(CountryModel data)
        {
            try
            {
                using (yk327Entities db = new yk327Entities())
                {
                    if (data.CountryId == 0)
                    {
                        if (db.country.Any(x => x.CountryName.ToLower() == data.CountryName.ToLower()))
                        {
                            TempData["country"] = "Already available";
                            return RedirectToAction("AllCountry", "Country");
                        }
                        else
                        {
                            db.sp_add_edit_country(null, data.CountryName);
                        }
                    }
                    else
                    {
                        db.sp_add_edit_country(data.CountryId, data.CountryName);
                    }
                }
                return RedirectToAction("AllCountry", "Country");
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }
        public ActionResult EditCountry(int id)
        {
            try
            {
                country ShowCountryInfo;
                using (yk327Entities db = new yk327Entities())
                {
                    ShowCountryInfo = db.country.ToList().Find(x => x.CountryId == id);
                }
                CountryModel country = new CountryModel()
                {
                    CountryId = ShowCountryInfo.CountryId,
                    CountryName = ShowCountryInfo.CountryName
                };
                return View("AddCountry", country);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }
        public ActionResult DeleteCountry(int id)
        {
            try
            {
                using (yk327Entities db = new yk327Entities())
                {
                    var success = db.state.Any(x => x.CountryId == id);
                    if (success == false)
                    {
                        db.sp_delete_country(id);
                        return RedirectToAction("AllCountry", "Country");
                    }
                    else
                    {
                        TempData["country"] = "Country in use";
                        return RedirectToAction("AllCountry", "Country");
                    }
                }
            }
            catch (Exception Exce)
            {
                TempData["country"] = "Somthing went wrong";
                return RedirectToAction("AllCountry", "Country");
            }
        }
        public ActionResult CountryDetalisById(int id)
        {
            using (yk327Entities db = new yk327Entities())
            {
               country countries =  db.country.Where(x => x.CountryId == id).FirstOrDefault();
               return View(countries);
            }
        }
    }
}