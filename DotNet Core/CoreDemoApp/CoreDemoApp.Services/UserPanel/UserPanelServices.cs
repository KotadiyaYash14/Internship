using CoreDemoApp.Data.DbRepository.UserPanel;
using CoreDemoApp.Model.ViewModel.UserPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Services.UserPanel
{
    public class UserPanelServices : IUserPanelServices
    {

        #region Fields

        private readonly IUserPanelRepository userPanelRepository;

        #endregion

        #region Constructor

        public UserPanelServices (IUserPanelRepository _userPanelRepository)
        {
            userPanelRepository = _userPanelRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Register User Method
        /// </summary>
        public async Task<int> RegisterUser(UserData userData)
        {
            return await userPanelRepository.RegisterUser(userData);
        }

        /// <summary>
        /// Update Login Token Method
        /// </summary>
        public async Task<int> UpdateLoginToken(string Token, long UserId)
        {
            return await userPanelRepository.UpdateLoginToken(Token, UserId);
        }

        /// <summary>
        /// User Login Method
        /// </summary>
        public async Task<UserData> UserLogin(SignIn signIn)
        {
           return await userPanelRepository.UserLogin(signIn);
        }

        /// <summary>
        /// Validate Token Method
        /// </summary>
        public async Task<long> ValidateUserTokenData(long UserId, string jwtToken, DateTime TokenValidDate)
        {
            return await userPanelRepository.ValidateUserTokenData(UserId, jwtToken, TokenValidDate);
        }

        #endregion
    }
}
