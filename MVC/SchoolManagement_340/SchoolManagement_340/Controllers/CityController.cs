using Newtonsoft.Json;
using SchoolManagement_340.Models.CustomModel;
using SchoolManagement_340.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement_340.Controllers
{
    public class CityController : Controller
    {
        public ICityInterface CityServices;
        public IStateInterface StateServices;
        public ICountryInterface CountryServices;
        public CityController(ICityInterface _cityServices, IStateInterface _stateServices, ICountryInterface _countryServices)
        {
            CityServices = _cityServices;
            StateServices = _stateServices;
            CountryServices = _countryServices;
        }
        public ActionResult AddEditCity(int? id)
        {
            if (id == null)
            {
                ViewBag.State = new SelectList(StateServices.GetStates(), "StateId", "StateName");
                ViewBag.Country = new SelectList(CountryServices.GetCountries(), "CountryId", "CountryName");
                return View();
            }
            else
            {
                ViewBag.State = new SelectList(StateServices.GetStates(), "StateId", "StateName");
                ViewBag.Country = new SelectList(CountryServices.GetCountries(), "CountryId", "CountryName");
                CustomCity City = CityServices.GetCityById(id);
                return View(City);
            }
        }
        [HttpPost]
        public ActionResult AddEditCity(CustomCity data, int? id)
        {
            if (id == 0)
            {
                CityServices.RegisterCity(data, 0);
                return RedirectToAction("ShowCity", "City");
            }
            else
            {
                CityServices.RegisterCity(data, id);
                return RedirectToAction("ShowCity", "City");
            }
        }
        public ActionResult ShowCity()
        {
            return View(CityServices.GetStateAndCountry());
        }

        public ActionResult DeleteCity(int? id)
        {
            CityServices.DeleteCity(id);
            return RedirectToAction("ShowCity", "City");
        }
        public JsonResult StateAsPerCountry(int id)
        {
            var success = StateServices.GetStateByCountry(id);
            var JsonString = JsonConvert.SerializeObject(success);
            return Json(JsonString,JsonRequestBehavior.AllowGet);
        }
    }
}