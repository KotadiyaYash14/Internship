using CoreDemoApp.Model.ViewModel.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Services.Country
{
    public interface ICountryServices
    {
        Task<List<CountryData>> GetAllCountry();

        Task<int> AddEditCountry(CountryData country);

        Task<CountryData> GetCountryById(int id);

        Task<int> DeleteCountry(int id);
    }
}
