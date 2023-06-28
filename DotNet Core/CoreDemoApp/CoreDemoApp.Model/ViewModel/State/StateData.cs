using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Model.ViewModel.State
{
    public class StateData
    {
        public int StateId { get; set; }
        [Required]
        public string? StateName { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public string? CountryName { get; set; }
    }
}
