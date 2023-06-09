using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_340.Helper.SignUpHelper
{
    public class SignUpHelper
    {
        public User ConvertCustomSignUpToSignUp(CustomSignUp data)
        {
            User user = new User()
            {
                UserId = data.UserId,
                UserFirstName = data.UserFirstName,
                UserLastName = data.UserLastName,
                UserEmail = data.UserEmail,
                UserPassword = data.UserPassword,
                UserRole = (int)data.Role
            };
            return user;
        }
        public CustomSignUp ConvertSignUpToCustomSignUp(User data)
        {
            CustomSignUp user = new CustomSignUp()
            {
                UserId = data.UserId,
                UserFirstName = data.UserFirstName,
                UserLastName = data.UserLastName,
                UserEmail = data.UserEmail,
                UserPassword = data.UserPassword,
                Role = (Models.GlobalEnum.RoleType)data.UserRole
            };
            return user;
        }

        public User ConvertCustomSignInToSignIn(CustomSignIn data)
        {
            User user = new User()
            {
                UserEmail = data.UserEmail,
                UserPassword = data.UserPassword
            };
            return user;
        }
    }
}
