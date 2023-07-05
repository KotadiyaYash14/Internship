using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;

namespace VadtalDham.Filter
{
    public class CustomAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        #region Methods

        /// <summary>
        /// OnAuthorization Method
        /// </summary>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? customerJWTToken = Convert.ToString(context.HttpContext.Session.GetString("_userToken"));
            if (!string.IsNullOrEmpty(customerJWTToken))
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken? token = handler.ReadToken(customerJWTToken) as JwtSecurityToken;
                if (token != null)
                {
                    if (token.ValidTo < DateTime.UtcNow.AddMinutes(1))
                    {
                        context.HttpContext.Session.Clear();
                        context.HttpContext.Response.Cookies.Delete(".Admin.Session");
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            action = "SignIn",
                            controller = "Login",
                            returnUrl = context.HttpContext.Request.Path.Value
                        }));
                    }
                }
            }
            else
            {
                context.HttpContext.Session.Clear();
                context.HttpContext.Response.Cookies.Delete(".Admin.Session");
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    action = "SignIn",
                    controller = "Login",
                    returnUrl = context.HttpContext.Request.Path.Value
                }));
            }
        }

        #endregion
    }
}
