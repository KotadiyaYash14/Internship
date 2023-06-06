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
        public bool AlreadyRegister(CustomSignIn data)
        {
            if (db.User.Any(x => x.UserEmail == data.UserEmail && x.UserPassword == data.UserPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
