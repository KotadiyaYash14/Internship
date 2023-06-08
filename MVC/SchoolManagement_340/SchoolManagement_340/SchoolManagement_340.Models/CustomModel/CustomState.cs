using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_340.Models.CustomModel
{
    public class CustomState
    {
        public int StateId { get; set; }
        [Required]
        public string StateName { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
