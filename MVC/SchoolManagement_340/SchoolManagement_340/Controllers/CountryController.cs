using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using SchoolManagement_340.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement_340.Controllers
{
    public class CountryController : Controller
    {
        public ICountryInterface CountryServices;
        public CountryController(ICountryInterface _countryServices)
        {
            CountryServices = _countryServices;
        }
        public ActionResult AddEditCountry(int? id)
        {
            if(id == null)
            {
               return View();
            }
            else
            {
                CustomCountry country = CountryServices.GetCountryById(id);
                return View(country);
            } 
        }
        [HttpPost]
        public ActionResult AddEditCountry(CustomCountry data, int? id)
        {
            if(id == 0)
            {
                CountryServices.RegisterCountry(data, 0);
                return RedirectToAction("ShowCountry", "Country");
            }
            else
            {
                CountryServices.RegisterCountry(data, id);
                return RedirectToAction("ShowCountry", "Country");
            }
        }
        public ActionResult DeleteCountry(int ? id)
        {
            if(CountryServices.DeleteCountry(id) == 0)
            {
                TempData["Error"] = "Country is in Use";
            }
            return RedirectToAction("ShowCountry", "Country");
        }
        public ActionResult ShowCountry()
        {
            return View(CountryServices.GetCountries());
        }
    }
}