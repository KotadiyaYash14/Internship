using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using VadtalDham.Common.Helpers;
using VadtalDham.Model.Config;
using VadtalDham.Model.ViewModel.UserPanel;

namespace VadtalDham.Data.DbRepository.UserPanel
{
    public class UserPanelRepository : BaseRepository, IUserPanelRepository
    {
        #region Fields

        private IConfiguration configuration;

        #endregion

        #region Constructor

        public UserPanelRepository(IConfiguration _configuration, IOptions<DataConfig> dataconfig) : base(dataconfig, _configuration)
        {
            configuration = _configuration;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sign In Method
        /// </summary>
        public async Task<UserData> UserLogin(SignIn signIn)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@UserEmail", signIn.UserEmail);
                param.Add("@UserPassword", signIn.Password);
                return await QueryFirstOrDefaultAsync<UserData>(StoredProcedures.UserLogin, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Update Login Token Method
        /// </summary>
        public async Task<int> UpdateLoginToken(string Token, long UserId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@userid", UserId);
                param.Add("@token", Token);
                var data = await ExecuteAsync<int>(StoredProcedures.UpdateLoginToken, param, commandType: CommandType.StoredProcedure);
                return data;
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Validate Token Method
        /// </summary>
        public async Task<long> ValidateUserTokenData(long UserId, string jwtToken, DateTime TokenValidDate)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@userid", UserId);
                param.Add("@jwttoken", jwtToken);
                param.Add("@tokenvaliddate", TokenValidDate.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                return await ExecuteAsync<long>(StoredProcedures.ValidateUserTokenData, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Get User By Email Method
        /// </summary>
        public async Task<Forgot> GetUserDetailsByEmail(Forgot user)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@UserEmail", user.UserEmail);
                return await QueryFirstOrDefaultAsync<Forgot>(StoredProcedures.GetUserDetailsByEmail, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// OTP Verification Method
        /// </summary>
        public async Task<int> OTPVerification(int OTP, string email)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@otp", OTP);
                param.Add("@useremail", email);
                var OTPData = await QueryFirstOrDefaultAsync<int>(StoredProcedures.OTPVerification, param, commandType: CommandType.StoredProcedure);
                return OTPData;
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Update User Password Method
        /// </summary>
        public async Task<int> UpdatePassword(string password, string email)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@newpassword", password);
                param.Add("@useremail", email);
                var UpdatePasswordData = await QueryFirstOrDefaultAsync<int>(StoredProcedures.UpdatePassword, param, commandType: CommandType.StoredProcedure);
                return UpdatePasswordData;
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Update OTP Method
        /// </summary>
        public async Task<int> UpdateOTP(int UserId, int OTP)
        {
            var param = new DynamicParameters();
            param.Add("@userid", UserId);
            param.Add("@otp",OTP);
            var UpdateOTPData = await ExecuteAsync<int>(StoredProcedures.UpdateOTP, param, commandType: CommandType.StoredProcedure);
            return UpdateOTPData;
        }

        #endregion
    }
}
