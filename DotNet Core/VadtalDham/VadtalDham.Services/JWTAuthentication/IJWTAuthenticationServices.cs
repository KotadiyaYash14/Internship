using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VadtalDham.Model.Token;

namespace VadtalDham.Services.JWTAuthentication
{
    public interface IJWTAuthenticationServices
    {
        string GenerateToken(string EmailAddress, string UserId, string SecretKey, double JWT_Validity_Mins);

        AccessTokenModel GenerateTokenModel(UserTokenModel userToken, string JWT_Secret, int JWT_Validity_Mins);

        UserTokenModel GetUserTokenData(string jwtToken);
    }
}
