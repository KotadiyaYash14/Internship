using CoreDemoApp.Data.DbRepository.City;
using CoreDemoApp.Data.DbRepository.Country;
using CoreDemoApp.Data.DbRepository.State;
using CoreDemoApp.Data.DbRepository.UserPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Data
{
    public class DataRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var types = new Dictionary<Type, Type>()
            {
                { typeof( IUserPanelRepository ), typeof(UserPanelRepository ) },
                { typeof( ICountryRepository ), typeof(CountryRepository ) },
                { typeof( IStateRepository ), typeof(StateRepository ) },
                { typeof( ICityRepository ), typeof(CityRepository ) }
            };
            return types;
        }
    }
}
