using CoreDemoApp.Data.DbRepository.City;
using CoreDemoApp.Data.DbRepository.State;
using CoreDemoApp.Model.ViewModel.City;
using CoreDemoApp.Model.ViewModel.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Services.City
{
    public class CityServices : ICityServices
    {
        #region Fields

        public ICityRepository cityRepository;

        #endregion

        #region Constructor

        public CityServices(ICityRepository _cityRepository)
        {
            cityRepository = _cityRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get All City Method
        /// </summary>
        public async Task<List<CityData>> GetAllCity()
        {
           return await cityRepository.GetAllCity();
        }

        /// <summary>
        /// Delete City Method
        /// </summary>
        public async Task<int> DeleteCity(int id)
        {
            return await cityRepository.DeleteCity(id);
        }

        /// <summary>
        /// Add Edit City Method
        /// </summary>
        public async Task<int> AddEditCity(CityData city)
        {
          return await cityRepository.AddEditCity(city);
        }

        /// <summary>
        /// Get City By Id Method
        /// </summary>
        public async Task<CityData> GetCityById(int id)
        {
            return await cityRepository.GetCityById(id);
        }

        /// <summary>
        /// Get States By Country Id Method
        /// </summary>
        public async Task<List<StateData>> GetStateByCountryId(int id)
        {
            return await cityRepository.GetStateByCountryId(id);
        }

        #endregion
    }
}
