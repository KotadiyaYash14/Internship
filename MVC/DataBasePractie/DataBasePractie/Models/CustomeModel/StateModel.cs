using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DataBasePractie.Models.CustomeModel
{
    public class StateModel
    {
        public int StateId { get; set; }
        [Required]
        public string StateName { get; set; }
        [Required]
        public int? CountryId { get; set; }
    }
}