using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistration.Controllers
{
    public class CountryController : Controller
    {
        // GET: AddressInfo
        public ActionResult AddCountry()
        {
            try
            {
                //List<Country> country;
                //using (CP356ChiragPatelEntities CountryName = new CP356ChiragPatelEntities())
                //{
                //    country = CountryName.Country.ToList();
                //}
                //ViewBag.CountryName = new SelectList(country, "CountryId", "CountryName");
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error505");
            }
        }
        [HttpPost]
        public ActionResult AddCountry(Country data)
        {
            try
            {
                if (data.CountryId == 0)
                {
                    using (CP356ChiragPatelEntities Country = new CP356ChiragPatelEntities())
                    {
                        Country.sp_Add_Edit_School_Country(null, data.CountryName);
                        Country.SaveChanges();
                    }
                    return RedirectToAction("ShowCountry");
                }
                else
                {
                    using (CP356ChiragPatelEntities country = new CP356ChiragPatelEntities())
                    {
                        country.sp_Add_Edit_School_Country(data.CountryId, data.CountryName);
                        country.SaveChanges();
                    }
                    return RedirectToAction("ShowCountry");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error505");
            }
        }
        public ActionResult ShowCountry()
        {
            try
            {
                List<v_Show_School_Country> Country;
                using (CP356ChiragPatelEntities country = new CP356ChiragPatelEntities())
                {
                    Country = country.v_Show_School_Country.ToList();
                }
                return View(Country);
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error505");
            }
        }
        public ActionResult EditCountryName(int id)
        {
            try
            {
                Country ShowCountryInfo;
                using (CP356ChiragPatelEntities CountryInfo = new CP356ChiragPatelEntities())
                {
                    ShowCountryInfo = CountryInfo.Country.Where(x => x.CountryId == id).FirstOrDefault();

                }

                return View("AddCountry", ShowCountryInfo);
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error505");
            }
        }
        public ActionResult DeleteCountry(int id)
        {try
            {
                using (CP356ChiragPatelEntities CountryInfo = new CP356ChiragPatelEntities())
                {
                    CountryInfo.sp_Delete_School_Country(id);
                    CountryInfo.SaveChanges();
                }
                return RedirectToAction("ShowCountry");
            }
            catch (Exception) { return RedirectToAction("/Error/Error505"); }
        }
    }
}