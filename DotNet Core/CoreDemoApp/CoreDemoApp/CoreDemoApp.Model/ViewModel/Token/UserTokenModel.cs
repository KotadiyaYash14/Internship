using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Model.ViewModel.Token
{
    public class UserTokenModel
    {
        public long UserId { get; set; }
        public DateTime TokenValidTo { get; set; }
        public string? EmailId { get; set; }
        public string? UserName { get; set; }
    }
}
