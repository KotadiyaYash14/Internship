using CoreDemoApp.Common.Helpers;
using CoreDemoApp.Model.Config;
using CoreDemoApp.Model.ViewModel.UserPanel;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Data.DbRepository.UserPanel
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
        /// Register User Method
        /// </summary>
        public async Task<int> RegisterUser(UserData userData)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@UserId", userData.UserId);
                param.Add("@UserName", userData.UserName);
                param.Add("@UserEmail", userData.UserEmail);
                param.Add("@UserPassword", userData.Password);
                return await ExecuteAsync<int>(StoredProcedures.RegisterUser, param, commandType: System.Data.CommandType.StoredProcedure);
                //return await ExecuteAsync<int>("sp_RegisterUser", param, commandType: System.Data.CommandType.StoredProcedure);
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
                var data =  await ExecuteAsync<int>(StoredProcedures.UpdateLoginToken, param, commandType: CommandType.StoredProcedure);
                return data;
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// User Login Method
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

        #endregion
    }
}
