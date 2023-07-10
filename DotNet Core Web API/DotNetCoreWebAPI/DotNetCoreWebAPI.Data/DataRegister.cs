using DotNetCoreWebAPI.Data.DbRepository.Country;
using DotNetCoreWebAPI.Data.DbRepository.State;
using DotNetCoreWebAPI.Data.DbRepository.UserPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Data
{
    public  class DataRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var types = new Dictionary<Type, Type>()
            {
                { typeof( IUserPanelRepository ), typeof( UserPanelRepository ) },
                { typeof( ICountryRepository ), typeof( CountryRepository ) },
                { typeof( IStateRepository ), typeof( StateRepository ) }
            };
            return types;
        }
    }
}
