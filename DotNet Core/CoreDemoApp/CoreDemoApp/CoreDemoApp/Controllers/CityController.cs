using CoreDemoApp.Filters;
using CoreDemoApp.Model.ViewModel.City;
using CoreDemoApp.Model.ViewModel.State;
using CoreDemoApp.Services.City;
using CoreDemoApp.Services.Country;
using CoreDemoApp.Services.State;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CoreDemoApp.Controllers
{
    [TypeFilter(typeof(CustomAuthorizationFilter))]
    [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any, NoStore = true)]
    public class CityController : Controller
    {
        #region Fields

        public ICityServices cityServices;
        public IStateServices stateServices;
        public ICountryServices countryServices;

        #endregion

        #region Constructor

        public CityController(ICityServices _cityServices, IStateServices _stateServices, ICountryServices _countryServices)
        {
            cityServices = _cityServices;
            stateServices = _stateServices;
            countryServices = _countryServices;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get All City From Database
        /// </summary>
        public async Task<IActionResult> CityList()
        {
            try
            {
                var City = await cityServices.GetAllCity();
                return View(City);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Delete City Method
        /// </summary>
        public async Task<IActionResult> DeleteCity(int id)
        {
            try
            {
                await cityServices.DeleteCity(id);
                TempData["Delete"] = "Deleted";
                return RedirectToAction("CityList");
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Add Edit City Method
        /// </summary>
        public async Task<IActionResult> AddEditCity(int id)
        {
            try
            {
                if (id == 0)
                {
                    ViewBag.ID = id;
                    ViewBag.State = new SelectList(await stateServices.GetAllState(), "StateId", "StateName");
                    ViewBag.Country = new SelectList(await countryServices.GetAllCountry(), "CountryId", "CountryName");
                    return View();
                }
                else
                {
                    ViewBag.ID = id;
                    var City = await cityServices.GetCityById(id);
                    ViewBag.State = new SelectList(await cityServices.GetStateByCountryId(City.CountryId), "StateId", "StateName");
                    ViewBag.Country = new SelectList(await countryServices.GetAllCountry(), "CountryId", "CountryName");
                    return View(City);
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Add Edit City Post Method
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddEditCity(CityData city)
        {
            try
            {
                var City = await cityServices.AddEditCity(city);
                if(City == 0 && city.CityId == 0)
                {
                    TempData["Available"] = "City Already Exists";
                    return RedirectToAction("AddEditCity");
                }
                else if (city.CityId == 0 && City != 0)
                {
                    TempData["Register"] = "City added Successfully";
                    return RedirectToAction("CityList");
                }
                else if (city.CityId != 0 && City != 0)
                {
                    TempData["Update"] = "City Updated Successfully";
                    return RedirectToAction("CityList");
                }
                else
                {
                    return RedirectToAction("CityList");
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Get States By Country Id Method
        /// </summary>
        public async Task<JsonResult> GetStatesByCountyId(int id)
        {
            try
            {
                List<StateData> state = await cityServices.GetStateByCountryId(id);
                var states = from s in state select new { StateName = s.StateName, StateId = s.StateId };
                var jsonString = JsonConvert.SerializeObject(states);
                return Json(jsonString);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        #endregion
    }
}
