using SchoolManagement_340.Helper.SignUpHelper;
using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using SchoolManagement_340.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_340.Repository.Services
{
    public class UserPanel_Services : IUserPanel_Interface
    {
        SchoolManagement_yk_340Entities db = new SchoolManagement_yk_340Entities();
        SignUpHelper suh = new SignUpHelper();
        public bool RegisterUser(CustomSignUp data)
        {
            try
            {
                User UserInfo = suh.ConvertCustomSignUpToSignUp(data);
                if (UserInfo != null)
                {
                    db.User.Add(UserInfo);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }
        public int AlreadyRegister(CustomSignIn data)
        {
            if (db.User.Any(x => x.UserEmail == data.UserEmail && x.UserPassword == data.UserPassword))
            {
                return 0;
            }
            //else if (db.User.Any(x => x.UserEmail == data.UserEmail && x.UserPassword != data.UserPassword))
            //{
            //    return 1;
            //}
            //else if (db.User.Any(x => x.UserEmail != data.UserEmail && x.UserPassword == data.UserPassword))
            //{
            //    return 2;
            //}
            else
            {
                return 1;
            }
        }

        public User IsEmailExists(CustomSignUp data)
        {
            User user = db.User.Where(x => x.UserEmail.ToLower() == data.UserEmail.ToLower()).FirstOrDefault();
            if(user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public User GetUserNameFromEmailForSession(string email)
        {
            User user = db.User.Where(x => x.UserEmail.ToLower() == email.ToLower()).FirstOrDefault();
            return user;
        }
    }
}
