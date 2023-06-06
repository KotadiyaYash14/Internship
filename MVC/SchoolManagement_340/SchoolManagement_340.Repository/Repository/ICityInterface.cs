using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_340.Repository.Repository
{
    public interface ICityInterface
    {
        bool RegisterCity(CustomCity data, int ? id);
        List<sp_getStateCountryList_Result> GetStateAndCountry();
        int DeleteCity(int? id);
        CustomCity GetCityById(int? id);
        List<City> GetCityByState(int? id);
    }
}
