using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SchoolManagement_340.API.Controllers
{
    public class CountryController : ApiController
    {
        SchoolManagement_yk_340Entities db = new SchoolManagement_yk_340Entities();
        public CountryController()
        {

        }
        public async Task<IHttpActionResult> GetAllCountry()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Country> Countries = await db.Country.ToListAsync();
            return Ok(Countries);
        }
        public async Task<IHttpActionResult> GetCountryById(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Country countries = await db.Country.Where(x => x.CountryId == id).FirstOrDefaultAsync();
            return Ok(countries);
        }

        public IHttpActionResult PostAddEditcountry(CustomCountry data)
        {
            if (data.CountryId == 0)
            {
                if (db.Country.Any(x => x.CountryName.ToLower() == data.CountryName.ToLower()) == false)
                {
                    db.sp_add_edit_country(0, data.CountryName);
                    return Ok();
                }
                else
                {
                    return Ok();
                }
            }
            else
            {
                db.sp_add_edit_country(data.CountryId, data.CountryName);
                return Ok();
            }
        }
        public IHttpActionResult DeleteCountry(int ? id)
        {
            var success = db.State.Any(x => x.CountryId == id);
            if (success == true)
            {
                return Ok();
            }
            else
            {
                db.sp_delete_country(id);
                return Ok();
            }
        }
    }
}
