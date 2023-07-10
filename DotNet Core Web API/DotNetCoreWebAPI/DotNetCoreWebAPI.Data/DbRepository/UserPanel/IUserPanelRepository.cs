using DotNetCoreWebAPI.Model.ViewModel.UserPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Data.DbRepository.UserPanel
{
    public interface IUserPanelRepository
    {
        Task<UserData> UserLogin(SignIn data);

        Task<int> RegisterUser(UserData userData);

        Task<int> ValidateUserTokenData(long UserId, string jwtToken, DateTime TokenValidDate);

        Task<int> UpdateLoginToken(string Token, long UserId);
    }
}
