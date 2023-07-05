using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VadtalDham.Model.Token
{
    public class AccessTokenModel
    {
        public string? Token { get; set; }
        public int ValidityInMin { get; set; }
        public DateTime ExpiresOnUTC { get; set; }
        public long UserId { get; set; }
    }
}
