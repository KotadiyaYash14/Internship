using DataBasePractie.Models.Context;
using DataBasePractie.Models.CustomeModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBasePractie.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        public ActionResult AllCity()
        {
            List<sp_get_city_Result> Cities;
            using (yk327Entities db = new yk327Entities())
            {
                Cities = db.sp_get_city().ToList();
            }
            return View(Cities);
        }
        public ActionResult AddCity(int? id)
        {
            if (id != null)
            {
                city cityinfo;
                using (yk327Entities db = new yk327Entities())
                {
                    cityinfo = db.city.ToList().Find(x => x.cityId == id);
                    CityModel city = new CityModel()
                    {
                        cityId = cityinfo.cityId,
                        cityName = cityinfo.cityName,
                        StateId = cityinfo.StateId,
                        CountryId =cityinfo.CountryId
                    };
                    ViewBag.countryList = new SelectList(db.country.ToList(), "CountryId", "CountryName");
                    ViewBag.stateList = new SelectList(db.state.ToList(), "StateId", "StateName");
                    return View(city);
                }
            }
            else
            {
                using (yk327Entities db = new yk327Entities())
                {
                    ViewBag.countryList = new SelectList(db.country.ToList(), "CountryId", "CountryName");
                    ViewBag.stateList = new SelectList(db.state.ToList(), "StateId", "StateName");
                    return View();
                }
            }
        }
        [HttpPost]
        public ActionResult AddCity(CityModel data)
        {
            using (yk327Entities db = new yk327Entities())
            {
                var success = db.city.Any(x => x.cityName.ToLower() == data.cityName.ToLower());
                if (success == false)
                {
                    if (data.cityId == 0)
                    {
                        db.sp_add_edit_city(null, data.cityName, data.StateId, data.CountryId);
                    }
                    else
                    {
                        db.sp_add_edit_city(data.cityId, data.cityName, data.StateId, data.CountryId);
                    }
                    return RedirectToAction("AllCity", "City");
                }
            }
            return View();
        }

        public ActionResult DeleteCity(int id)
        {
            using (yk327Entities db = new yk327Entities())
            {
                db.sp_delete_city(id);
                return RedirectToAction("AllCity", "City");
            }
        }
        public ActionResult CityDetails(int id)
        {
            using (yk327Entities db = new yk327Entities())
            {
                city cities = db.city.Where(x => x.cityId == id).FirstOrDefault();
                state states = db.state.Where(x => x.StateId == cities.StateId).FirstOrDefault();
                country country = db.country.Where(x => x.CountryId == cities.CountryId).FirstOrDefault();
                ViewBag.StateName = states.StateName;
                ViewBag.CountryName = country.CountryName;
                return View(cities);
            }
        }
        public JsonResult StateAsPerCountry(int id)
        {
            using (yk327Entities db = new yk327Entities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                var MyState = db.state.Where(x => x.CountryId == id).ToList();
                var JsonString = JsonConvert.SerializeObject(MyState);
                return Json(MyState, JsonRequestBehavior.AllowGet);
            }
        }
    }
}