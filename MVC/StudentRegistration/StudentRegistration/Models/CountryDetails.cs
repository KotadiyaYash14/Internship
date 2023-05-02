using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistration.Models
{
    [MetadataType(typeof(Metadata))]
    public partial class Country
    {
        internal class Metadata
        {
            [Required]
            public int CountryId { get; set; }
            
            [Required]
            public string CountryName { get; set; }
        }
    }
}