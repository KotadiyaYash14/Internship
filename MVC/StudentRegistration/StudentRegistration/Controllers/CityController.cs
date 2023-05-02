using Newtonsoft.Json;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace StudentRegistration.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        public ActionResult AddCity()
        {
            try
            {
                List<Country> Country;
                using (CP356ChiragPatelEntities Countryname = new CP356ChiragPatelEntities())
                {
                    Country = Countryname.Country.ToList();
                }
                ViewBag.CountryName = new SelectList(Country, "CountryId", "CountryName");
                ViewBag.StateName = new SelectList("");
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error505");
            }

        }
        [HttpPost]
        public ActionResult AddCity(City city)
        {
            try
            {
                if (city.CityId == 0)
                {
                    using (CP356ChiragPatelEntities CityInfo = new CP356ChiragPatelEntities())
                    {
                        var message = CityInfo.sp_Add_Edit_School_City(null, city.CityName, city.StateId);
                        CityInfo.SaveChanges();
                    }
                    return RedirectToAction("ShowCity");
                }
                else
                {
                    using (CP356ChiragPatelEntities CityInfo = new CP356ChiragPatelEntities())
                    {
                        var message = CityInfo.sp_Add_Edit_School_City(city.CityId, city.CityName, city.StateId);
                        CityInfo.SaveChanges();
                    }
                    return RedirectToAction("ShowCity");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error505");
            }
        }
        public ActionResult ShowCity()
        {
            try
            {
                List<v_Show_School_City> City;
                using (CP356ChiragPatelEntities db = new CP356ChiragPatelEntities())
                {
                    City = db.v_Show_School_City.ToList();
                }
                return View(City);
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error505");
            }
        }
        public JsonResult GetStates(int id)
        {
            try
            {
                List<State> state;
                using (CP356ChiragPatelEntities countryId = new CP356ChiragPatelEntities())
                {
                    state = countryId.State.Where(x => x.CountryId == id).ToList();
                }
                var states = from s in state select new { StateName = s.StateName, StateId = s.StateId };
                var jsonString = JsonConvert.SerializeObject(states);
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public ActionResult EditCityName(int id)
        {
            try
            {
                City ShowCityInfo;
                using (CP356ChiragPatelEntities CityInfo = new CP356ChiragPatelEntities())
                {
                    ShowCityInfo = CityInfo.City.Include("State").ToList().Where(x => x.CityId == id).FirstOrDefault();

                }
                List<Country> country;
                List<State> state;
                using (CP356ChiragPatelEntities countryname = new CP356ChiragPatelEntities())
                {
                    country = countryname.Country.ToList();
                    state = countryname.State.ToList().Where(x => x.CountryId == ShowCityInfo.State.CountryId).ToList();
                }
                ViewBag.CountryName = new SelectList(country, "CountryId", "CountryName");
                ViewBag.StateName = new SelectList(state, "StateId", "StateName");
                return View("AddCity", ShowCityInfo);
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error505");
            }
        }
        public ActionResult DeleteCityName(int id)
        {
            try
            {
                using (CP356ChiragPatelEntities db = new CP356ChiragPatelEntities())
                {
                    db.sp_Delete_School_City(id);
                    db.SaveChanges();
                }
                return RedirectToAction("ShowCity");
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error505");
            }
        }
    }
}