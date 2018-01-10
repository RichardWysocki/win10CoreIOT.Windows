namespace Services.ASPNETCore.Docker.Model
{
    public class WebSettings
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string AuthUserName { get; set; }
        public string AuthPassword { get; set; }

    }
}
