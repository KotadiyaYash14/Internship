using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Model.ViewModel.UserPanel
{
    public class SignIn
    {
        [Required]
        public string? UserEmail {  get; set; }
        [Required]
        public string? Password { get; set; }    
    }

    public class UserData
    {
        public int UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? UserEmail { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
