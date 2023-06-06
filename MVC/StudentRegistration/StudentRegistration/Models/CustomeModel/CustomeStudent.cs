using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistration.Models.CustomeModel
{
    public class CustomeStudent
    {
        public int studentid { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invvalida StudentName")]
        public string studentname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string studentemail { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string studentphone { get; set; }
        [Required]
        public System.DateTime studentdob { get; set; }
        [Required]
        public string studentgender { get; set; }
        [Required]
        public string studentaddress { get; set; }
        [Required]
        public int studentcountry { get; set; }
        [Required]
        public int stuentstate { get; set; }
        [Required]
        public int studentcity { get; set; }
        [Required(ErrorMessage = "Zip is Required")]
        [RegularExpression(@"^\d{6}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        public string studentpincode { get; set; }
    }
}