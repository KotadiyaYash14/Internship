using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_340.Helper.SignUpHelper
{
    public class CityHelper 
    {
        public City ConvertCustomCityToCity(CustomCity data)
        {
            City city = new City() 
            { 
                CityId = data.CityId,
                CityName = data.CityName,
                StateId = data.StateId,
                CountryId = data.CountryId
            };
            return city;
        }
        public CustomCity ConvertCityToCustomCity(City data)
        {
            CustomCity ch = new CustomCity()
            {
               CityId = data.CityId,
               CityName = data.CityName,
               StateId = (int)data.StateId,
               CountryId = (int)data.CountryId
            };
            return ch;
        }
    }
}
