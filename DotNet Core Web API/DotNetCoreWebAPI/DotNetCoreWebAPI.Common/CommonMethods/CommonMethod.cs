using DotNetCoreWebAPI.Model.RequestResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DotNetCoreWebAPI.Common.CommonMethods
{
    public class CommonMethod
    {
        public static ParamValue GetKeyValues(HttpContext context)
        {
            ParamValue paramValues = new ParamValue();
            var headerValue = string.Empty;
            var queryString = string.Empty;
            var jsonString = string.Empty;
            StringValues outValue = string.Empty;

            // for from header value
            if (context.Request.Headers.TryGetValue("requestModel", out outValue))
            {
                headerValue = outValue.FirstOrDefault();
                JObject jsonobj = JsonConvert.DeserializeObject<JObject>(headerValue);
                if (jsonobj != null)
                {
                    Dictionary<string, string> keyValueMap = new Dictionary<string, string>();
                    foreach (KeyValuePair<string, JToken> keyValuePair in jsonobj)
                    {
                        keyValueMap.Add(keyValuePair.Key, keyValuePair.Value.ToString());
                    }
                    List<RequestResponseKeyValue> keyValueMapNew = keyValueMap.ToList().Select(i => new RequestResponseKeyValue
                    {
                        Key = i.Key,
                        Value = i.Value
                    }).ToList();
                    jsonString = JsonConvert.SerializeObject(keyValueMapNew);
                }
            }

            // for from query value
            if (context.Request.QueryString.HasValue)
            {
                var dict = HttpUtility.ParseQueryString(context.Request.QueryString.Value);
                queryString = System.Text.Json.JsonSerializer.Serialize(
                                    dict.AllKeys.ToDictionary(k => k, k => dict[k]));
            }


            paramValues.HeaderValue = jsonString;
            paramValues.QueryStringValue = queryString;
            return paramValues;
        }
    }
}
