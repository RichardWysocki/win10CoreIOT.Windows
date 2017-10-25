namespace win10Core.Business.Model
{
    public interface IEmailConfiguration
    {
        string SMTPServer { get; set; }

        string SmtpServerUserName { get; set; }

        string SmtpServerPassword { get; set; }

    }
}