using Newtonsoft.Json;
using StudentRegistration.Models.Context;
using StudentRegistration.Models.CustomeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistration.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        yk327Entities1 db = new yk327Entities1();
        public ActionResult ShowStudent()
        {
            List<student> students;
            students = db.student.ToList();
            return View(students);
        }

        public ActionResult AddStudent(int? id)
        {
            if (id != null)
            {
                student StudnetInfo;
                StudnetInfo = db.student.ToList().Find(x => x.studentid == id);
                CustomeStudent student = new CustomeStudent()
                {
                    studentid = StudnetInfo.studentid,
                    studentname = StudnetInfo.studentname,
                    studentemail = StudnetInfo.studentemail,
                    studentphone = StudnetInfo.studentphone,
                    studentdob = StudnetInfo.studentdob,
                    studentgender = StudnetInfo.studentgender,
                    studentaddress = StudnetInfo.studentaddress,
                    studentcountry = (int)StudnetInfo.studentcountry,
                    stuentstate = (int)StudnetInfo.stuentstate,
                    studentcity = (int)StudnetInfo.studentcity,
                    studentpincode = StudnetInfo.studentpincode
                };
                ViewBag.Country = new SelectList(db.country.ToList(), "CountryId", "CountryName");
                ViewBag.State = new SelectList(db.state.ToList(), "StateId", "StateName");
                ViewBag.City = new SelectList(db.city.ToList(), "cityId", "cityName");
                return View(student);
            }
            else
            {
                ViewBag.Country = new SelectList(db.country.ToList(), "CountryId", "CountryName");
                ViewBag.State = new SelectList(db.state.ToList(), "StateId", "StateName");
                ViewBag.City = new SelectList(db.city.ToList(), "cityId", "cityName");
                return View();
            }
        }
        [HttpPost]
        public ActionResult AddStudent(CustomeStudent data)
        {
            if (data.studentid == 0)
            {
                db.sp_add_edit_student(null, data.studentname, data.studentemail, data.studentphone, data.studentdob, data.studentgender, data.studentaddress, data.studentcountry, data.stuentstate, data.studentcity, data.studentpincode);
            }
            else
            {
                db.sp_add_edit_student(data.studentid, data.studentname, data.studentemail, data.studentphone, data.studentdob, data.studentgender, data.studentaddress, data.studentcountry, data.stuentstate, data.studentcity, data.studentpincode);
            }
            return RedirectToAction("ShowStudent", "Student");
        }
        //public ActionResult EditStudent()
        //{

        //}

        public ActionResult DeleteStudent(int id)
        {
            var success = db.student.Any(x => x.studentid == id);
            if (success == true)
            {
                db.sp_delete_student(id);
                return RedirectToAction("ShowStudent", "Student");
            }
            else
            {
                ViewBag.Error = "This Student Does Not Exist";
                return RedirectToAction("ShowStudent", "Student");
            }
        }
        public JsonResult StateAsPerCountry(int id)
        {
            {
                db.Configuration.ProxyCreationEnabled = false;
                var MyState = db.state.Where(x => x.CountryId == id).ToList();
                var JsonString = JsonConvert.SerializeObject(MyState);
                return Json(MyState, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult CityAsPerState(int id)
        {
            {
                db.Configuration.ProxyCreationEnabled = false;
                var MyCity = db.city.Where(x => x.StateId == id).ToList();
                var JsonString = JsonConvert.SerializeObject(MyCity);
                return Json(MyCity, JsonRequestBehavior.AllowGet);
            }
        }
    }
}