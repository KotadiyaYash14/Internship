using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistration.Controllers
{
    public class StateController : Controller
    {
        // GET: State
        public ActionResult AddState()
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
        public ActionResult AddState(State state)
        {
            try
            {
                if (state.StateId == 0)
                {
                    using (CP356ChiragPatelEntities StateInfo = new CP356ChiragPatelEntities())
                    {
                        var message = StateInfo.sp_Add_Edit_School_State(null, state.StateName, state.CountryId);
                        StateInfo.SaveChanges();
                    }
                    return RedirectToAction("ShowState");
                }
                else
                {
                    using (CP356ChiragPatelEntities StateInfo = new CP356ChiragPatelEntities())
                    {
                        var message = StateInfo.sp_Add_Edit_School_State(state.StateId, state.StateName, state.CountryId);
                        StateInfo.SaveChanges();
                    }
                    return RedirectToAction("ShowState");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error505");
            }
        }
        public ActionResult ShowState()
        {
            try
            {
                List<v_Show_School_State> State;
                using (CP356ChiragPatelEntities db = new CP356ChiragPatelEntities())
                {
                    State = db.v_Show_School_State.ToList();
                }
                return View(State);
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error505");
            }
        }
        public ActionResult EditStateName(int id)
        {
            try
            {
                State ShowStateInfo;
                using (CP356ChiragPatelEntities StateInfo = new CP356ChiragPatelEntities())
                {
                    ShowStateInfo = StateInfo.State.Where(x => x.StateId == id).FirstOrDefault();

                }
                List<Country> country;
                using (CP356ChiragPatelEntities countryname = new CP356ChiragPatelEntities())
                {
                    country = countryname.Country.ToList();
                }
                ViewBag.CountryName = new SelectList(country, "CountryId", "CountryName");

                return View("AddState", ShowStateInfo);
            }
            catch (Exception)
            {
                return RedirectToAction("/Error/Error505");
            }
        }
        public ActionResult DeleteState(int id)
            {try
                {
                    using (CP356ChiragPatelEntities db = new CP356ChiragPatelEntities())
                    {
                        db.sp_Delete_School_State(id);
                        db.SaveChanges();
                    }
                    return RedirectToAction("ShowState");
                }
                catch (Exception) { return RedirectToAction("/Error/Error505"); }
            }
    }
}