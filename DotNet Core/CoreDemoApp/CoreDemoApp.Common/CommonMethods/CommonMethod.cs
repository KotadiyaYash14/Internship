using CoreDemoApp.Model.Error;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CoreDemoApp.Common.CommonMethods
{
    #region Methods
    public class CommonMethod
    {
        /// <summary>
        /// Get Key Values Method
        /// </summary>
        public static string GetKeyValues(HttpContext context)
        {
            string json = string.Empty;
            if (context.Request != null && context.Request.HasFormContentType)
            {
                List<ReqResponseKeyValue> lstReqResponse = new List<ReqResponseKeyValue>();

                var data = context.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString()).ToList();

                for (int i = 0; i < data.Count - 1; i++)
                {
                    ReqResponseKeyValue obj = new ReqResponseKeyValue();
                    obj.Key = data[i].Key.ToString();
                    obj.Value = data[i].Value.ToString();

                    lstReqResponse.Add(obj);
                }

                if (lstReqResponse.Count > 0)
                {
                    json = JsonConvert.SerializeObject(lstReqResponse);
                }
            }
            return json;
        }

        /// <summary>
        /// Get Local Date Time Method
        /// </summary>
        public static DateTime GetLocalDateTime(DateTime dateTime)
        {
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Local);
        }

        #region Generate Salt
        public static string GenerateSalt()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            return Convert.ToBase64String(salt)
;
        }

        #endregion

        #region Get Hash

        public static byte[] GetHash(string plainPassword, string salt)
        {
            byte[] byteArray = Encoding.Unicode.GetBytes(string.Concat(salt, plainPassword));
            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashedBytes = sha256.ComputeHash(byteArray);
            return hashedBytes;
        }

        #endregion

        #region Compare Hashed Password

        public static bool CompareHashedPassword(string password, string existingHasedBase64StringPassword, string salt)
        {
            string userInputHashedPassword = Convert.ToBase64String(GetHash(password, salt));
            return existingHasedBase64StringPassword == userInputHashedPassword;
        }

        #endregion

        /// <summary>
        /// Get Query String Value Method
        /// </summary>
        public static string GetQueryStringValues(HttpContext context)
        {
            var queryString = string.Empty;
            if (context.Request.QueryString.HasValue)
            {
                var dict = HttpUtility.ParseQueryString(context.Request.QueryString.Value);
                queryString = System.Text.Json.JsonSerializer.Serialize(dict.AllKeys.ToDictionary(k => k, k => dict[k]));
            }

            return queryString;
        }
    }

    #endregion
}
