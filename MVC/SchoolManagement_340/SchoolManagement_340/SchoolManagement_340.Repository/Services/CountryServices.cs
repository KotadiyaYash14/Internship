using SchoolManagement_340.Helper.SignUpHelper;
using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using SchoolManagement_340.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_340.Repository.Services
{
    public class CountryServices : ICountryInterface
    {
        SchoolManagement_yk_340Entities db = new SchoolManagement_yk_340Entities();
        CountryHelper ch = new CountryHelper();

        public int DeleteCountry(int? id)
        {
            var success = db.State.Any(x => x.CountryId == id);
            if (success == true)
            {
                return 0;
            }
            else
            {
                db.sp_delete_country(id);
                return 1;
            }
        }

        public List<Country> GetCountries()
        {
            return db.Country.ToList();
        }
        public CustomCountry GetCountryById(int? id)
        {
            Country country = db.Country.Where(x => x.CountryId == id).FirstOrDefault();
            CustomCountry cc = ch.ConvertCountryToCustomCountry(country);
            return cc;
        }
        public bool RegisterCountry(CustomCountry data, int? id)
        {
            try
            {
                if (data != null)
                {
                    if (id == 0)
                    {
                        if (db.Country.Any(x => x.CountryName.ToLower() == data.CountryName.ToLower()) == false)
                        {
                            db.sp_add_edit_country(0, data.CountryName);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        db.sp_add_edit_country(data.CountryId, data.CountryName);
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
