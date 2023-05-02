using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyApplication.Models
{
    public class User

    {
        public static List<User> user_list = new List<User>();

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide UserId")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Your name Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name should be 3 to 50 characters.")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Eamil")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        public string UserEmail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Address")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "fdsfsdfdsf")]
        public string UserAddress { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide City")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Please Provide City")]
        public string UserCity { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide PinCode")]
        [DataType(DataType.PostalCode, ErrorMessage = " Please Enter Valid Postal Code")]
        public int UserPinCode { get; set; }
    }
}