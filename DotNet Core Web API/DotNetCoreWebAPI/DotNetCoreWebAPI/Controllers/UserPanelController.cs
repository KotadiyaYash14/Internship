using DotNetCoreWebAPI.Common.Helpers;
using DotNetCoreWebAPI.Model.AppSettings;
using DotNetCoreWebAPI.Model.Token;
using DotNetCoreWebAPI.Model.ViewModel.UserPanel;
using DotNetCoreWebAPI.Services.JWTAuthentication;
using DotNetCoreWebAPI.Services.UserPanel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DotNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPanelController : ControllerBase
    {
        #region Fields

        public IUserPanelServices userPanelServices;
        private readonly AppSetting _appSettings;
        private IJWTAuthenticationServices _jWTAuthenticationService;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        #endregion

        #region Constructor

        public UserPanelController(IUserPanelServices _userPanelServices, IOptions<AppSetting> appSettings, IJWTAuthenticationServices jWTAuthenticationService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            userPanelServices = _userPanelServices;
            _appSettings = appSettings.Value;
            _jWTAuthenticationService = jWTAuthenticationService;
            _hostingEnvironment = hostingEnvironment;
        }

        #endregion

        #region Methods

        [HttpPost("SignIn")]
        public async Task<ApiPostResponse<UserData>> SignIn(SignIn data)
        {
            ApiPostResponse<UserData> response = new ApiPostResponse<UserData>();

            var result = await userPanelServices.UserLogin(data);

            if (result != null)
            {
                UserTokenModel objTokenData = new UserTokenModel();

                objTokenData.EmailId = result.UserEmail;
                objTokenData.UserId = result.UserId != null ? result.UserId : 0;
                objTokenData.UserName = result.UserName;

                AccessTokenModel objAccessTokenData = new AccessTokenModel();

                // Genrate Token
                objAccessTokenData = _jWTAuthenticationService.GenerateToken(objTokenData, _appSettings.JWT_Secret, _appSettings.JWT_Validity_Mins);

                // Update Token
                await userPanelServices.UpdateLoginToken(objAccessTokenData.Token, objAccessTokenData.UserId);

                UserData AccessToken = new UserData();

                AccessToken.UserEmail = result.UserEmail;
                AccessToken.UserName = result.UserName;
                AccessToken.Token = objAccessTokenData.Token;
                //AccessToken.Password = data.Password;
                response.Success = true;
                response.Message = BaseApiMessage.LoginSuccess;
                response.Data = AccessToken;
                
            }
            else
            {
                response.Success = false;
                response.Message = BaseApiMessage.LoginFailed;
            }
            return response;
        }

        [HttpPost("SignUp")]
        public async Task<BaseApiResponse> SignUp([FromBody] UserData data)
        {
            BaseApiResponse response = new BaseApiResponse();
            var result = await userPanelServices.RegisterUser(data);
            if (result != 0)
            {
                response.Success = true;
                response.Message = BaseApiMessage.RegisterSuccess;
            }
            else
            {
                response.Success = false;
                response.Message = BaseApiMessage.RegisterFailed;
            }
            return response;
        }

        #endregion
    }
}
