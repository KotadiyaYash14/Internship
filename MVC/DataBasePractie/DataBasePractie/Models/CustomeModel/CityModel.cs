using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBasePractie.Models.CustomeModel
{
    public class CityModel
    {
        public int cityId { get; set; }
        public string cityName { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
    }
}