namespace win10Core.Business.Engine.Interface
{
    public interface IEmailEngine
    {
        void Send(string userName, string sender, string subject, string body, string[] recipients);

        void Send(string userName, string sender, string subject, string body, string recipient);

        string SendWithLog(string userName, string sender, string subject, string body, string[] recipients);
    }
}