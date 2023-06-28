using CoreDemoApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoApp.Controllers
{
    [TypeFilter(typeof(CustomAuthorizationFilter))]
    [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any, NoStore = true)]
    public class HomeController : Controller
    {
        #region Methods

        /// <summary>
        /// DashBoard Method
        /// </summary>
        public IActionResult DashBoard()
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

        #endregion
    }
}
