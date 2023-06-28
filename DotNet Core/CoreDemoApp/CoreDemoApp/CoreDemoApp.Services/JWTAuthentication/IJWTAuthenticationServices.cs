using CoreDemoApp.Model.ViewModel.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Services.JWTAuthentication
{
    public interface IJWTAuthenticationServices
    {
        string GenerateToken(string EmailAddress, string UserId, string SecretKey, double JWT_Validity_Mins);

        AccessTokenModel GenerateTokenModel(UserTokenModel userToken, string JWT_Secret, int JWT_Validity_Mins);

        UserTokenModel GetUserTokenData(string jwtToken);
    }
}
