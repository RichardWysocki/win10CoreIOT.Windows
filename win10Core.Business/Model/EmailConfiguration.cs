﻿namespace win10Core.Business.Model
{
    public class EmailConfiguration : IEmailConfiguration
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpServerUserName { get; set; }
        public string SmtpServerPassword { get; set; }
    }
}