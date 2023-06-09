using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SchoolManagement_340.Models.GlobalEnum;

namespace SchoolManagement_340.Models.CustomModel
{
    public class CustomSignUp
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid FirstName")]
        public string UserFirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Invalid LastName")]
        public string UserLastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail address")]
        public string UserEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=.*\d)(?=.*[A-Za-z]).{5,}", ErrorMessage = "Your password must be at least 5 characters long and contain at least 1 letter and 1 number")]
        public string UserPassword { get; set; }
        [Required]
        [Compare("UserPassword", ErrorMessage = "Please Re-enter Password Again")]
        public string ConfirmPassword { get; set; }
        [Required]
        public RoleType Role { get; set; }
        public int IamgeId { get; set; }
        public string Image { get; set; }
        //public string ImageTitle { get; set; }
        public HttpPostedFileBase ImagePath { get; set; }
    }
}
