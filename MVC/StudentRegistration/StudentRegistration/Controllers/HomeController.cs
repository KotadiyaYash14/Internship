using Newtonsoft.Json;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistration.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
       
        public ActionResult AddStudentInfo()
        {
            try
            {
                List<Country> country;
                using (CP356ChiragPatelEntities countryname = new CP356ChiragPatelEntities())
                {
                    country = countryname.Country.ToList();
                }
                ViewBag.CountryName = new SelectList(country, "CountryId", "CountryName");

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error505");
            }
        }
        [HttpPost]
        public ActionResult AddStudentInfo(SchoolStudentInfo data)
        {
            try
            {
                if (data.Id == 0)
                {
                    using (CP356ChiragPatelEntities StudentInfo = new CP356ChiragPatelEntities())
                    {
                        var message = StudentInfo.sp_Add_Edit_School_Student_Info(null, data.FName, data.LName, data.PhoneNumber, data.EmailId, data.BirthDate, data.Gender, data.Address, data.Country, data.State, data.City);
                        StudentInfo.SaveChanges();
                    }
                    return RedirectToAction("AddStudentInfo");
                }
                else
            {
                 
                    using (CP356ChiragPatelEntities StudentInfo = new CP356ChiragPatelEntities())
                    {
                        var message = StudentInfo.sp_Add_Edit_School_Student_Info(data.Id, data.FName, data.LName, data.PhoneNumber, data.EmailId, data.BirthDate, data.Gender, data.Address, data.Country, data.State, data.City);
                        StudentInfo.SaveChanges();
                    }
                    return RedirectToAction("ShowStudentData");
                }
                
            }
            catch (Exception) { return RedirectToAction("/Error/Error505"); }
        }
        public ActionResult EditStudentInfo(long id)
        {try
            {
                SchoolStudentInfo ShowStudentInfo;
                using (CP356ChiragPatelEntities StudentInfo = new CP356ChiragPatelEntities())
                {
                    ShowStudentInfo = StudentInfo.SchoolStudentInfo.Where(x => x.Id == id).FirstOrDefault();
                }
                List<Country> country;
                using (CP356ChiragPatelEntities countryname = new CP356ChiragPatelEntities())
                {
                    country = countryname.Country.ToList();
                }
                ViewBag.CountryName = new SelectList(country, "CountryId", "CountryName");
                return View("AddStudentInfo", ShowStudentInfo);
            }
            catch (Exception) { return RedirectToAction("/Error/Error505"); }
        }
        public ActionResult DeleteStudentInfo(long Id)
        {try
            {
                using (CP356ChiragPatelEntities StudentInfo = new CP356ChiragPatelEntities())
                {
                    StudentInfo.sp_Delete_School_Student_Info(Id);
                    StudentInfo.SaveChanges();
                }
                return RedirectToAction("ShowStudentData");
            }
            catch (Exception) { return RedirectToAction("/Error/Error505"); }
        }
        
        public ActionResult ShowStudentData()
        {try
            {
                List<sp_View_School_Student_Info_Result1> studentDetails;
                using (CP356ChiragPatelEntities student = new CP356ChiragPatelEntities())
                {
                    studentDetails = student.sp_View_School_Student_Info().ToList();
                }
                return View(studentDetails);
            }
            catch (Exception) { return RedirectToAction("/Error/Error505"); }
        }
        [AllowAnonymous]
        public JsonResult GetStates(int id)
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
        [AllowAnonymous]
        public JsonResult GetCites(int id)
        {
            List<City> city;
            using(CP356ChiragPatelEntities stateId = new CP356ChiragPatelEntities())
            {
                city = stateId.City.Where(x => x.StateId == id).ToList();
            }
            var cites = from c in city select new { CityName = c.CityName, CityId = c.CityId };
            var jsonString = JsonConvert.SerializeObject(cites);
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
    }
}