using DotNetCoreWebAPI.Data.DbRepository.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Services.Country
{
    public class CountryServices : ICountryServices
    {
        #region Fields

        private ICountryRepository countryRepository;

        #endregion

        #region Constructor

        public CountryServices(ICountryRepository _countryRepository)
        {
            countryRepository = _countryRepository;
        }

        #endregion

        #region Method

        public async Task<List<CountryData>> GetCountryListAsync()
        {
            return await countryRepository.GetCountryListAsync();
        }

        public async Task<int> AddEditCountry(CountryData countryData)
        {
            return await countryRepository.AddEditCountry(countryData);
        }

        public async Task<int> DeleteCountry(int id)
        {
            return await countryRepository.DeleteCountry(id);
        }

        #endregion
    }
}
