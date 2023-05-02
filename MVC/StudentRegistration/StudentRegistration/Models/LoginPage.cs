using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistration.Models
{
    [MetadataType(typeof(Metadata))]

    public partial class SchoolUserLogin
    {
        internal class Metadata
        {
            [Key]
            public int Id { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide First Name")]
            [StringLength(20, MinimumLength = 3, ErrorMessage = "First Name should be min 3 and max 20 length")]
            public string FName { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Last Name")]
            [StringLength(20, MinimumLength = 3, ErrorMessage = "Last Name should be min 3 and max 20 length")]
            public string LName { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Eamil")]
            [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
            public string EmailId { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Password")]
            [StringLength(15, MinimumLength = 8, ErrorMessage = "Password should be min 8 and max 15 length")]
            public string Password { get; set; }
        }

            [Required]
            [Compare("Password",ErrorMessage ="Password must be same")]
            public string CPassword { get; set; }
    }
}