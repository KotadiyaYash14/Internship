using SchoolManagement_340.Helper.SignUpHelper;
using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using SchoolManagement_340.Repository.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement_340.Repository.Services
{
    public class CityServices : ICityInterface
    {
        SchoolManagement_yk_340Entities db = new SchoolManagement_yk_340Entities();
        CityHelper ch = new CityHelper();

        public int DeleteCity(int? id)
        {
            if (db.City.Any(x => x.CityId == id))
            {
                db.sp_delete_city(id);
                return 1;
            }
            else
            {
               return 0;
            }
        }

        public CustomCity GetCityById(int? id)
        {
            City city = db.City.Where(x => x.CityId == id).FirstOrDefault();
            CustomCity cc = ch.ConvertCityToCustomCity(city);
            return cc;
        }

        public List<City> GetCityByState(int? id)
        {
            return db.City.Where(x => x.StateId == id).ToList();
        }

        public List<sp_getStateCountryList_Result> GetStateAndCountry()
        {
            return db.sp_getStateCountryList().ToList();
        }

        public bool RegisterCity(CustomCity data, int? id)
        {
            if (data != null)
            {
                if (id == 0)
                {
                    db.sp_add_edit_city(0, data.CityName, data.StateId, data.CountryId);
                    return true;
                }
                else
                {
                    db.sp_add_edit_city(data.CityId, data.CityName, data.StateId, data.CountryId);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
