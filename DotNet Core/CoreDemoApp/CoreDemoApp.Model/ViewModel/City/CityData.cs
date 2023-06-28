using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Model.ViewModel.City
{
    public class CityData
    {
        public int CityId { get; set; }
        [Required]
        public string? CityName { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        public string? StateName { get; set;}
        [Required]
        public int CountryId { get; set; }
        [Required]
        public string? CountryName { get; set;}
    }
}
