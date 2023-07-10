using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Data.DbRepository.Country
{
    public interface ICountryRepository
    {
        Task<List<CountryData>> GetCountryListAsync();

        Task<int> AddEditCountry(CountryData countryData);

        Task<int> DeleteCountry(int id);
    }
}
