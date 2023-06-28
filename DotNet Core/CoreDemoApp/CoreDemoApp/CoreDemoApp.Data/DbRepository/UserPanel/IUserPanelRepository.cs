using CoreDemoApp.Model.ViewModel.UserPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Data.DbRepository.UserPanel
{
    public interface IUserPanelRepository
    {
        Task<UserData> UserLogin(SignIn signIn);

        Task<int> RegisterUser(UserData userData);

        Task<long> ValidateUserTokenData(long UserId, string jwtToken, DateTime TokenValidDate);

        Task<int> UpdateLoginToken(string Token, long UserId);
    }
}
