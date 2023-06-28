using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Model.ViewModel.Country
{
    public class CountryData
    {
        public int CountryId { get; set; }
        [Required]
        public string? CountryName { get; set; }
    }
}
