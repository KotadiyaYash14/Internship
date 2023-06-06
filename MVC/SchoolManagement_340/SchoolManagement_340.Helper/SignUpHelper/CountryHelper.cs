using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_340.Helper.SignUpHelper
{
    public class CountryHelper
    {
        public Country ConvertCustomCountryToCountry(CustomCountry data)
        {
            Country country = new Country()
            {
                CountryId = data.CountryId,
                CountryName = data.CountryName
            };
            return country;
        }
        public CustomCountry ConvertCountryToCustomCountry(Country data)
        {
            CustomCountry cc = new CustomCountry()
            { 
                CountryId = data.CountryId,
                CountryName = data.CountryName
            };
            return cc;
        }
    }
}
