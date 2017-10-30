namespace win10Core.Business.Standard.Engine.Interface
{
    public interface ILogEngine
    {
        void LogInfo(string method, string message);

        void LogError(string source, string method, string message);
    }
}
