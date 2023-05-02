using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistration.Models
{
    [MetadataType(typeof(MetaData))]
    public partial class City
    {
        internal class MetaData
        {
            public int CityId { get; set; }
            public string CityName { get; set; }
            public Nullable<int> StateId { get; set; }
        }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}