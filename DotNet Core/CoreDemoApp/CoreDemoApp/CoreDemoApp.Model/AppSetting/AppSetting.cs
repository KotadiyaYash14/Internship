using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Model.AppSetting
{
    public  class AppSetting
    {
        public string? JWT_Secret { get; set; }
        public int JWT_Validity_Mins { get; set; }
    }
}
