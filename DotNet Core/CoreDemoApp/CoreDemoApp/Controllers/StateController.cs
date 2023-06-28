using CoreDemoApp.Filters;
using CoreDemoApp.Model.ViewModel.Country;
using CoreDemoApp.Model.ViewModel.State;
using CoreDemoApp.Services.Country;
using CoreDemoApp.Services.State;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Metrics;

namespace CoreDemoApp.Controllers
{
    [TypeFilter(typeof(CustomAuthorizationFilter))]
    [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any, NoStore = true)]
    public class StateController : Controller
    {
        #region Fields

        public IStateServices stateservices;
        public ICountryServices countryservices;

        #endregion

        #region Constructor

        public StateController(IStateServices _stateservices, ICountryServices _countryservices)
        {
            stateservices = _stateservices;
            countryservices = _countryservices;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get All State From Database
        /// </summary>
        public async Task<IActionResult> StateList()
        {
            try
            {
                var State = await stateservices.GetAllState();
                return View(State);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Delete State Method
        /// </summary>
        public async Task<IActionResult> DeleteState(int id)
        {
            try
            {
                var State = await stateservices.DeleteState(id);
                if (State == -1)
                {
                    TempData["Error"] = "State Is In Use";
                    return RedirectToAction("StateList");
                }
                else
                {
                    TempData["Delete"] = "Deleted";
                    return RedirectToAction("StateList");
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Add Edit State Method
        /// </summary>
        public async Task<IActionResult> AddEditState(int id)
        {
            try
            {
                if (id == 0)
                {
                    ViewBag.ID = id;
                    ViewBag.Country = new SelectList(await countryservices.GetAllCountry(), "CountryId", "CountryName");
                    return View();
                }
                else
                {
                    ViewBag.ID = id;
                    ViewBag.Country = new SelectList(await countryservices.GetAllCountry(), "CountryId", "CountryName");
                    var State = await stateservices.GetStateById(id);
                    return View(State);
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Add Edit State Post Method
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddEditState(StateData state)
        {
            try
            {
                var State = await stateservices.AddEditState(state);
                if(State == 0 && state.StateId == 0)
                {
                    TempData["Available"] = "Country Already Exists";
                    return RedirectToAction("AddEditState");
                }
                else if (state.StateId == 0 && State != 0)
                {
                    TempData["Register"] = "State added Successfully";
                    return RedirectToAction("StateList");
                }
                else if (state.StateId != 0 && State != 0)
                {
                    TempData["Update"] = "State Updated Successfully";
                    return RedirectToAction("StateList");
                }
                else
                {
                    return RedirectToAction("StateList");
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        #endregion
    }
}
