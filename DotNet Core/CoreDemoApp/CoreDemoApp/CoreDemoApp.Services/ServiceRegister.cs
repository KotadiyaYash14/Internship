using CoreDemoApp.Services.City;
using CoreDemoApp.Services.Country;
using CoreDemoApp.Services.JWTAuthentication;
using CoreDemoApp.Services.State;
using CoreDemoApp.Services.UserPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Services
{
    public class ServiceRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var ServiceDictionary = new Dictionary<Type, Type>()
            {
                { typeof ( IUserPanelServices ), typeof ( UserPanelServices ) },
                { typeof ( ICountryServices ), typeof ( CountryServices ) },
                { typeof ( IStateServices ), typeof ( StateServices ) },
                {typeof ( ICityServices ), typeof ( CityServices ) },
                //{typeof ( IJWTAuthenticationServices ), typeof ( JWTAuthenticationServices ) },
            };
            return ServiceDictionary;
        }
    }
}
