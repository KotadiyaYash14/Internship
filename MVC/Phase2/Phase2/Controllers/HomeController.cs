using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phase2.Models;

namespace Phase2.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
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

        public ActionResult About()
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

        public ActionResult Contact()
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
        public ActionResult Course()
        {
            List<string> Courses = new List<string>();
            Courses.Add("CE");
            Courses.Add("IT");
            Courses.Add("EC");
            Courses.Add("Chemical");
            ViewData["Courses"] = Courses;
            return View();
        }
        public ActionResult StudentList()
        {
            try
            {
                return View(Db.StudentLists);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }
        public ActionResult Create()
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
        public ActionResult Create(StudentList data)
        {
            try
            {
                Db.StudentLists.Add(data);
                return RedirectToAction("Create");
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }
        public ActionResult Edit(int id)
        {
            try
            {
                StudentList stu = Db.StudentLists.Where(x => x.StudentId == id).FirstOrDefault();
                return View(stu);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }
        [HttpPost]
        public ActionResult Edit(StudentList data)
        {
            StudentList stu = Db.StudentLists.Where(x => x.StudentId == data.StudentId).FirstOrDefault();
            stu.StudentId = data.StudentId;
            stu.StudentFirstName = data.StudentFirstName;
            stu.StudentLastName = data.StudentLastName;
            stu.StudentAge = data.StudentAge;
            stu.StudentAddress = data.StudentAddress;
            return RedirectToAction("StudentList");
        }
        public ActionResult Delete(int id)
        {
            try
            {
                StudentList stu = Db.StudentLists.Find(x => x.StudentId == id);
                Db.StudentLists.Remove(stu);
                return RedirectToAction("StudentList");
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }
    }
}