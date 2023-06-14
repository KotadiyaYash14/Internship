using Newtonsoft.Json;
using PagedList;
using SchoolManagement_340.Helper.SessionHelper;
using SchoolManagement_340.Models.CustomModel;
using SchoolManagement_340.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement_340.Controllers
{
    //[Authorize]
    [Validate]
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
            try
            {
                if (id == null)
                {
                    ViewBag.State = new SelectList(StateServices.GetStates(), "StateId", "StateName");
                    ViewBag.Country = new SelectList(CountryServices.GetCountries(), "CountryId", "CountryName");
                    return View();
                }
                else
                {
                    CustomCity City = CityServices.GetCityById(id);
                    ViewBag.State = new SelectList(StateServices.GetStateByCountry(City.CountryId), "StateId", "StateName");
                    ViewBag.Country = new SelectList(CountryServices.GetCountries(), "CountryId", "CountryName");
                    return View(City);
                }
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult AddEditCity(CustomCity data, int? id)
        {
            try
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
            catch
            {
                return View();
            }
        }
        public ActionResult ShowCity(int ? page)
        {
            try
            {
                int pageSize = 2; 
                int pageNumber = (page ?? 1);
                return View(CityServices.GetStateAndCountry().ToPagedList(pageNumber, pageSize));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteCity(int? id)
        {
            try
            {
                if (CityServices.DeleteCity(id) == 1)
                {
                    TempData["Error"] = "City is in Use";
                }
                return RedirectToAction("ShowCity", "City");
            }
            catch
            {
                return View();
            }
        }
        public JsonResult StateAsPerCountry(int id)
        {
            try
            {
                var success = StateServices.GetStateByCountry(id);
                var JsonString = JsonConvert.SerializeObject(success);
                return Json(JsonString, JsonRequestBehavior.AllowGet);
            }
            catch(Exception Exce)
            {
                return Json(Exce,JsonRequestBehavior.AllowGet);
            }
        }
    }
}