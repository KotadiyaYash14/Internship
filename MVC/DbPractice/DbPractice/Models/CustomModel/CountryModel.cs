using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DbPractice.Models.CustomModel
{
    public class CountryModel
    {
        public int CountryId { get; set; }
        [Required(ErrorMessage ="Please Enter Country Name")]
        [StringLength(20, MinimumLength =3, ErrorMessage ="Please Enter Valid Length")]
        public string CountryName { get; set; }
    }
}