using Dapper;
using DotNetCoreWebAPI.Common.Helpers;
using DotNetCoreWebAPI.Model.DataConfig;
using DotNetCoreWebAPI.Model.ViewModel.UserPanel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Data.DbRepository.UserPanel
{
    public class UserPanelRepository : BaseRepository, IUserPanelRepository
    {
        #region Fields

        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public UserPanelRepository(IConfiguration configuration, IOptions<DataConfig> dataconfig) : base(dataconfig, configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task<UserData> UserLogin(SignIn data)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@UserEmail", data.UserEmail);
                param.Add("@UserPassword", data.Password);
                return await QueryFirstOrDefaultAsync<UserData>("sp_UserLogin", param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        public async Task<int> RegisterUser(UserData userData)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@UserId", userData.UserId);
                param.Add("@UserName", userData.UserName);
                param.Add("@UserEmail", userData.UserEmail);
                param.Add("@UserPassword", userData.Password);
                param.Add("@IsActive", 1);
                param.Add("@IsDelete", 0);
                return await ExecuteAsync<int>(StoredProcedure.RegisterUser, param, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }

        public async Task<int> ValidateUserTokenData(long UserId, string jwtToken, DateTime TokenValidDate)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@userid", UserId);
                param.Add("@jwttoken", jwtToken);
                param.Add("@tokenvaliddate", TokenValidDate);
                return await QueryFirstOrDefaultAsync<int>(StoredProcedure.ValidateUserTokenData, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        public async Task<int> UpdateLoginToken(string Token, long UserId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@userid", UserId);
                param.Add("@token", Token);
                var data = await ExecuteAsync<int>(StoredProcedure.UpdateLoginToken, param, commandType: CommandType.StoredProcedure);
                return data;
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        #endregion
    }
}