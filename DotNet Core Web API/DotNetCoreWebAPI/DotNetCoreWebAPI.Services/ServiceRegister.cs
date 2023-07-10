using DotNetCoreWebAPI.Services.Country;
using DotNetCoreWebAPI.Services.JWTAuthentication;
using DotNetCoreWebAPI.Services.State;
using DotNetCoreWebAPI.Services.UserPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Services
{
    public class ServiceRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var ServiceDictionary = new Dictionary<Type, Type>()
            {
                { typeof ( IUserPanelServices ), typeof ( UserPanelServices ) },
                { typeof ( ICountryServices ), typeof ( CountryServices ) },
                { typeof ( IStateServices ), typeof ( StateServices ) }
            };
            return ServiceDictionary;
        }
    }
}
