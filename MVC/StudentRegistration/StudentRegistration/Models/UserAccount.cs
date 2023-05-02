using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistration.Models
{
    public class UserAccount
    {
        public SchoolUserLogin UserLogin(SchoolUserLogin userLogin)
        {
            try
            {
                using (CP356ChiragPatelEntities UserLoginInfo = new CP356ChiragPatelEntities())
                {
                    var logininfo = UserLoginInfo.SchoolUserLogin.ToList().Find(x => x.EmailId == userLogin.EmailId && x.Password == userLogin.Password);
                    return logininfo;
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public int UserRegister(SchoolUserLogin userRegister)
        {
            try
            {
                using(CP356ChiragPatelEntities UserRegisterInfo = new CP356ChiragPatelEntities())
                {
                    UserRegisterInfo.SchoolUserLogin.Add(userRegister);
                    UserRegisterInfo.SaveChanges();
                }
                return 1;
            }
            catch(Exception e)
            {
                return 0;
            }
        }
    }
}