namespace win10Core.Business.Model
{
    public interface IEmailConfiguration
    {
        string SmtpServer { get; set; }

        int SmtpPort { get; set; }

        string SmtpServerUserName { get; set; }

        string SmtpServerPassword { get; set; }

    }
}