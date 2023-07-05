using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VadtalDham.Model.ViewModel.UserPanel
{
    public class SignIn
    {
        [Required (ErrorMessage = "Email Address is Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string? UserEmail { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
    }
    public class UserData
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "UserName is Required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email Address is Required")]
        public string? UserEmail { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
    }
    public class Forgot
    {
        public int UserId { get; set; }
        
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email Address is Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string? UserEmail { get; set; }
        
        public string? UserPassword { get; set; }
    }
    public class OTPModel
    {
        [Required(ErrorMessage = "OTP is Required")]
        public int OTP { get; set; }
    }
    public class UpdatePassword
    {
        [Required(ErrorMessage = "Please Enter New Password")]
        public string? NewPassword { get; set; }
        [Required]
        [Compare("NewPassword", ErrorMessage = "Password Doesn't match!")]
        public string? ConfirmPassword { get; set; }
    }


}
