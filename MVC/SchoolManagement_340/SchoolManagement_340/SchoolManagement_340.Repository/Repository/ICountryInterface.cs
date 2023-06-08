using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_340.Repository.Repository
{
    public interface ICountryInterface
    {
        bool RegisterCountry(CustomCountry data,int? id);
        CustomCountry GetCountryById(int? id);
        List<Country> GetCountries();
        int DeleteCountry(int? id);
    }
}
