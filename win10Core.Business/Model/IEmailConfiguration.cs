namespace win10Core.Business.Engine
{
    public interface IEmailConfiguration
    {
        string SMTPServer { get; set; }

        string SmtpServerUserName { get; set; }

        string SmtpServerPassword { get; set; }
    }

    public class EmailConfiguration : IEmailConfiguration
    {
        public string SMTPServer { get; set; }
        public string SmtpServerUserName { get; set; }
        public string SmtpServerPassword { get; set; }
    }
}