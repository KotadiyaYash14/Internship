using CoreDemoApp.Filters;
using CoreDemoApp.Model.ViewModel.Country;
using CoreDemoApp.Services.Country;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoApp.Controllers
{
    [TypeFilter(typeof(CustomAuthorizationFilter))]
    [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any, NoStore = true)]
    public class CountryController : Controller
    {
        #region Fields 

        private ICountryServices countryServices;

        #endregion

        #region Constructor

        public CountryController(ICountryServices _countryServices)
        {
            countryServices = _countryServices;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get All Country From Database
        /// </summary>

        public async Task<IActionResult> CountryList()
        {
            try
            {
                var Country = await countryServices.GetAllCountry();
                return View(Country);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        ///  Add Edit Country Method
        /// </summary>

        public async Task<IActionResult> AddEditCountry(int id)
        {
            try
            {
                if (id == 0)
                {
                    ViewBag.ID = id;
                    return View();
                }
                else
                {
                    var Country = await countryServices.GetCountryById(id);
                    ViewBag.ID = id;
                    return View(Country);
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Add Edit Country Post Method
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> AddEditCountry(CountryData country)
        {
            try
            {
                var Country = await countryServices.AddEditCountry(country);
                if(Country == 0 && country.CountryId == 0)
                {
                    TempData["Available"] = "Country Already Exists";
                    return RedirectToAction("AddEditCountry");
                }
                else if (country.CountryId == 0 && Country != 0)
                {
                    TempData["Register"] = "Country added Successfully";
                    return RedirectToAction("CountryList");
                }
                else if(country.CountryId != 0 && Country != 0)
                {
                    TempData["Update"] = "Country Updated Successfully";
                    return RedirectToAction("CountryList");
                }
                else
                {
                    return RedirectToAction("CountryList");
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Delete Country Method
        /// </summary>
        public async Task<IActionResult> DeleteCountry(int id)
        {
            try
            {
                var Country = await countryServices.DeleteCountry(id);
                if (Country == -1)
                {
                    TempData["Error"] = "Country Is In Use";
                    return RedirectToAction("CountryList");
                }
                else
                {
                    TempData["Delete"] = "Deleted";
                    return RedirectToAction("CountryList");
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
