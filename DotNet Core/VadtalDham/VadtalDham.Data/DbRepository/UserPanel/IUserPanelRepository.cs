using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VadtalDham.Model.ViewModel.UserPanel;

namespace VadtalDham.Data.DbRepository.UserPanel
{
    public interface IUserPanelRepository
    {
        Task<UserData> UserLogin(SignIn signIn);

        Task<long> ValidateUserTokenData(long UserId, string jwtToken, DateTime TokenValidDate);

        Task<int> UpdateLoginToken(string Token, long UserId);

        Task<Forgot> GetUserDetailsByEmail(Forgot user);

        Task<int> OTPVerification(int OTP, string email);

        Task<int> UpdatePassword(string password, string email);

        Task<int> UpdateOTP(int UserId, int OTP);

    }
}
