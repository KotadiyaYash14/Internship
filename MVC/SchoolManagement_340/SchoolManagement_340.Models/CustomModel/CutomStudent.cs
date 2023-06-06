using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_340.Models.CustomModel
{
    public class CustomStudent
    {
        public int StudentId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid Name")]
        public string StudentName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail address")]
        public string StudentEmail { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string StuentPhone { get; set; }
        [Required]
        public DateTime StudentDOB { get; set; }
        [Required]
        public string StudentGender { get; set; }
        [Required]
        public string StudentAddress { get; set; }
        [Required]
        public int StudentCountry { get; set; }
        [Required]
        public int StudentState { get; set; }
        [Required]
        public int StudentCity { get; set; }
    }
}
