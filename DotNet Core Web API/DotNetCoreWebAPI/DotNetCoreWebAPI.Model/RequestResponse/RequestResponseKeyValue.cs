using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Model.RequestResponse
{
    public class RequestResponseKeyValue
    {
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
    public class ParamValue
    {
        public string? HeaderValue { get; set; }
        public string? QueryStringValue { get; set; }
    }
}
