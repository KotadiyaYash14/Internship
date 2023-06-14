using Newtonsoft.Json;
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
    public class StudentController : Controller
    {
        public ICityInterface CityServices;
        public IStateInterface StateServices;
        public ICountryInterface CountryServices;
        public IStudentInterface StudentServices;
        public StudentController(ICityInterface _cityServices, IStateInterface _stateServices, ICountryInterface _countryServices, IStudentInterface _studentServices)
        {
            CityServices = _cityServices;
            StateServices = _stateServices;
            CountryServices = _countryServices;
            StudentServices = _studentServices;
        }
        public ActionResult AddEditStudent(int? id)
        {
            try
            {
                if (id == null)
                {
                    ViewBag.Country = new SelectList(CountryServices.GetCountries(), "CountryId", "CountryName");
                    ViewBag.State = new SelectList("");
                    ViewBag.City = new SelectList("");
                    return View();
                }
                else
                {
                    ViewBag.Country = new SelectList(CountryServices.GetCountries(), "CountryId", "CountryName");
                    CustomStudent sc = StudentServices.GetStudentById(id);
                    ViewBag.Date = sc.StudentDOB.ToString("yyyy-MM-dd");
                    ViewBag.State = new SelectList(StateServices.GetStateByCountry(sc.StudentCountry), "StateId", "StateName");
                    ViewBag.City = new SelectList(CityServices.GetCityByState(sc.StudentState), "CityId", "CityName");
                    return View(sc);
                }
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult AddEditStudent(CustomStudent data, int? id)
        {
            try
            {
                if (id == 0)
                {
                    StudentServices.RegisterStudent(data, 0);
                    return RedirectToAction("ShowStudent", "Student");
                }
                else
                {
                    StudentServices.RegisterStudent(data, id);
                    return RedirectToAction("ShowStudent", "Student");
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ShowStudent()
        {
            try
            {
                return View(StudentServices.GetAllStudent());
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteStudent(int? id)
        {
            try
            {
                StudentServices.DeleteStudent(id);
                return RedirectToAction("ShowStudent", "Student");
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
            catch (Exception Exce)
            {
                return Json(Exce, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult CityAsPerState(int id)
        {
            try
            {
                var success = CityServices.GetCityByState(id);
                var JsonString = JsonConvert.SerializeObject(success);
                return Json(JsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Exce)
            {
                return Json(Exce, JsonRequestBehavior.AllowGet);
            }
        }
    }
}