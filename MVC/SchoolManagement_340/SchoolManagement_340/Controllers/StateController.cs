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
    public class StateController : Controller
    {
        public IStateInterface StateServices;
        public ICountryInterface CountryServices;
        public StateController(IStateInterface _stateServices, ICountryInterface _countryServices)
        {
            StateServices = _stateServices;
            CountryServices = _countryServices;
        }
        public ActionResult AddEditState(int? id)
        {
            try
            {
                if (id == null)
                {
                    ViewBag.Country = new SelectList(CountryServices.GetCountries(), "CountryId", "CountryName");
                    return View();
                }
                else
                {
                    ViewBag.Country = new SelectList(CountryServices.GetCountries(), "CountryId", "CountryName");
                    CustomState state = StateServices.GetStateById(id);
                    return View(state);
                }
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult AddEditState(CustomState data, int? id)
        {
            try
            {
                if (id == null)
                {
                    StateServices.RegisterState(data, 0);
                    return RedirectToAction("ShowState", "State");
                }
                else
                {
                    StateServices.RegisterState(data, id);
                    return RedirectToAction("ShowState", "State");
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ShowState()
        {
            try
            {
                return View(StateServices.GetStates());
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteState(int? id)
        {
            try
            {
                if (StateServices.DeleteState(id) == 0)
                {
                    TempData["Error"] = "State is in Use";
                }
                return RedirectToAction("ShowState", "State");
            }
            catch
            {
                return View();
            }
        }
    }
}