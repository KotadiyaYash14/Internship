using SchoolManagement_340.Models.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_340.Repository.Repository
{
    public interface IUserPanel_Interface
    {
        bool RegisterUser(CustomSignUp data);
        bool AlreadyRegister(CustomSignIn data);
    }
}
