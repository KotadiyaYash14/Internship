using DotNetCoreWebAPI.Data.DbRepository.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Services.Country
{
    public interface ICountryServices
    {
        Task<List<CountryData>> GetCountryListAsync();

        Task<int> AddEditCountry(CountryData countryData);

        Task<int> DeleteCountry(int id);
    }
}
