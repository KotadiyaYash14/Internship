using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VadtalDham.Data.DbRepository.UserPanel;
using VadtalDham.Model.ViewModel.UserPanel;

namespace VadtalDham.Services.UserPanel
{
    public class UserPanelServices : IUserPanelServices
    {

        #region Fields

        private readonly IUserPanelRepository userPanelRepository;

        #endregion

        #region Constructor

        public UserPanelServices(IUserPanelRepository _userPanelRepository)
        {
            userPanelRepository = _userPanelRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sign In Method
        /// </summary>
        public async Task<UserData> UserLogin(SignIn signIn)
        {
            return await userPanelRepository.UserLogin(signIn);
        }

        /// <summary>
        /// Update Login Token Method
        /// </summary>
        public async Task<int> UpdateLoginToken(string Token, long UserId)
        {
            return await userPanelRepository.UpdateLoginToken(Token, UserId);
        }

        /// <summary>
        /// Validate Token Method
        /// </summary>
        public async Task<long> ValidateUserTokenData(long UserId, string jwtToken, DateTime TokenValidDate)
        {
            return await userPanelRepository.ValidateUserTokenData(UserId, jwtToken, TokenValidDate);
        }

        /// <summary>
        /// Get User By Email Method
        /// </summary>
        public async Task<Forgot> GetUserDetailsByEmail(Forgot user)
        {
            return await userPanelRepository.GetUserDetailsByEmail(user);
        }

        /// <summary>
        /// OTP Verification Method
        /// </summary>
        public async Task<int> OTPVerification(int OTP, string email)
        {
            return await userPanelRepository.OTPVerification(OTP, email);
        }

        /// <summary>
        /// Update User Password Method
        /// </summary>
        public async Task<int> UpdatePassword(string email, string password)
        {
            return await userPanelRepository.UpdatePassword(email, password);
        }

        /// <summary>
        /// Update OTP Method
        /// </summary>
        public async Task<int> UpdateOTP(int UserId, int OTP)
        {
            return await userPanelRepository.UpdateOTP(UserId, OTP);
        }

        #endregion
    }
}
