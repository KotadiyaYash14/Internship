using DotNetCoreWebAPI.Model.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Services.JWTAuthentication
{
    public interface IJWTAuthenticationServices
    {
        AccessTokenModel GenerateToken(UserTokenModel userToken, string JWT_Secret, int JWT_Validity_Mins);
        UserTokenModel GetUserTokenData(string jwtToken);
    }
}
