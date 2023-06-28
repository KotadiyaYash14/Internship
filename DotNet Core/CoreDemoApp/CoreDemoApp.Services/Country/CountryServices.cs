using CoreDemoApp.Data.DbRepository.Country;
using CoreDemoApp.Model.ViewModel.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Services.Country
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

        #region Methods

        /// <summary>
        /// Add Edit Country Method
        /// </summary>
        public async Task<int> AddEditCountry(CountryData country)
        {
            return await countryRepository.AddEditCountry(country);
        }

        /// <summary>
        /// Delete Country Method
        /// </summary>
        public async Task<int> DeleteCountry(int id)
        {
            return await countryRepository.DeleteCountry(id);
        }

        /// <summary>
        /// Get All Country Method
        /// </summary>
        public async Task<List<CountryData>> GetAllCountry()
        {
           return await countryRepository.GetAllCountry();
        }

        /// <summary>
        /// Get Country By Id Method
        /// </summary>
        public async Task<CountryData> GetCountryById(int id)
        {
            return await countryRepository.GetCountryById(id);
        }

        #endregion
    }
}
