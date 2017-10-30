namespace win10Core.Business.Standard.Model
{
    public interface IEmailConfiguration
    {
        string SMTPServer { get; set; }

        string SmtpServerUserName { get; set; }

        string SmtpServerPassword { get; set; }

    }
}