using CoreDemoApp.Model.ViewModel.City;
using CoreDemoApp.Model.ViewModel.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Data.DbRepository.City
{
    public interface ICityRepository
    {
        Task<List<CityData>> GetAllCity();

        Task<int> DeleteCity(int id);

        Task<int> AddEditCity(CityData city);

        Task<CityData> GetCityById(int id);

        Task<List<StateData>> GetStateByCountryId(int id);
    }
}
