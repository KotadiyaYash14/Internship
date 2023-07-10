using DotNetCoreWebAPI.Data.DbRepository.UserPanel;
using DotNetCoreWebAPI.Model.ViewModel.UserPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Services.UserPanel
{
    public class UserPanelServices : IUserPanelServices
    {
        #region Fields

        public IUserPanelRepository userPanelRepository;

        #endregion

        #region Constructor

        public UserPanelServices(IUserPanelRepository _userPanelRepository)
        {
            userPanelRepository = _userPanelRepository;
        }

        #endregion

        #region Methods

        public async Task<int> RegisterUser(UserData userData)
        {
            return await userPanelRepository.RegisterUser(userData);
        }

        public async Task<int> UpdateLoginToken(string Token, long UserId)
        {
            return await userPanelRepository.UpdateLoginToken(Token, UserId);
        }

        public async Task<UserData> UserLogin(SignIn data)
        {
            return await userPanelRepository.UserLogin(data);
        }

        public async Task<int> ValidateUserTokenData(long UserId, string jwtToken, DateTime TokenValidDate)
        {
            return await userPanelRepository.ValidateUserTokenData(UserId, jwtToken, TokenValidDate);
        }

        #endregion
    }
}
