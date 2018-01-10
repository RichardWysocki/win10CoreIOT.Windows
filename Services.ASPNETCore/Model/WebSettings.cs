using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using win10Core.Business;

namespace Services.ASPNETCore.Model
{
    public class WebSettings
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string AuthUserName { get; set; }
        public string AuthPassword { get; set; }

    }
}
