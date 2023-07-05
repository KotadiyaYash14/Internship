using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VadtalDham.Model.SMTPSetting
{
    public class SMTPSetting
    {
        public string? EmailAppPassword { get; set; }
        public string? EmailEnableSsl { get; set; }
        public string? EmailHostName { get; set; }
        public string? EmailPort { get; set; }
        public string? EmailUsername { get; set; }
        public string? FromEmail { get; set; }
        public string? FromName { get; set; }
    }
}
