using DataBasePractie.Models.Context;
using DataBasePractie.Models.CustomeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBasePractie.Controllers
{
    public class StateController : Controller
    {
        // GET: State
        public ActionResult AllState()
        {
            try
            {
                List<sp_get_state_Result> States;
                using (yk327Entities db = new yk327Entities())
                {
                    States = db.sp_get_state().ToList();
                }
                return View(States);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }
        public ActionResult AddState(int? id)
        {
            if (id != null)
            {
                state ShowStateInfo;
                using (yk327Entities db = new yk327Entities())
                {
                    ShowStateInfo = db.state.ToList().Find(x => x.StateId == id);
                    StateModel state = new StateModel()
                    {
                        StateId = ShowStateInfo.StateId,
                        StateName = ShowStateInfo.StateName,
                        CountryId = ShowStateInfo.CountryId
                    };
                    ViewBag.countryList = new SelectList(db.country.ToList(), "CountryId", "CountryName");
                    return View(state);
                }
            }
            else
            {
                using (yk327Entities db = new yk327Entities())
                {
                    ViewBag.countryList = new SelectList(db.country.ToList(), "CountryId", "CountryName");
                    return View();
                }
            }
        }
        [HttpPost]
        public ActionResult AddState(StateModel data)
        {
            using (yk327Entities db = new yk327Entities())
            {
                var success = db.state.Any(x => x.StateName.ToLower() == data.StateName.ToLower());
                if (success == false)
                {
                    if (data.StateId == 0)
                    {
                        db.sp_add_edit_state(null, data.StateName, data.CountryId);
                    }
                    else
                    {
                        db.sp_add_edit_state(data.StateId, data.StateName, data.CountryId);
                    }
                    return RedirectToAction("AllState", "State");
                }
                else
                {
                    TempData["State"] = "Already available";
                    return RedirectToAction("AllState", "State");
                }
            }
        }
        public ActionResult DeleteState(int id)
        {
            using(yk327Entities db = new yk327Entities())
            {
                var success = db.city.Any(x => x.StateId == id);
                if (success == false)
                {
                    db.sp_delete_state(id);
                    return RedirectToAction("AllState", "State");
                }
                else
                {
                    TempData["State"] = "State in use";
                    return RedirectToAction("AllState", "State");
                }
            }
        }
        public ActionResult StateDetails(int id)
        {
            using(yk327Entities db = new yk327Entities())
            {
                state states = db.state.Where(x => x.StateId == id).FirstOrDefault();
                country country = db.country.Where(x => x.CountryId == states.CountryId).FirstOrDefault();
                ViewBag.CountryName = country.CountryName;
                return View(states);
            }
        }
    }
}