using win10Core.Business.DataAccess;
using win10Core.Business.Model;

namespace win10Core.Business.Engine
{
    public class LogEngine : ILogEngine
    {
        private readonly ILogInfoDataAccess _logInfoDataAccess;
        private readonly ILogErrorDataAccess _logErrorDataAccess;


        public LogEngine(ILogInfoDataAccess logInfoDataAccess, ILogErrorDataAccess logErrorDataAccess)
        {
            _logInfoDataAccess = logInfoDataAccess;
            _logErrorDataAccess = logErrorDataAccess;
        }

        public void LogInfo(string method, string message)
        {
            _logInfoDataAccess.Insert(new LogInfo { Method = method, Message = message });
        }

        public void LogError(string source, string method, string message)
        {
            _logErrorDataAccess.Insert(new LogError {LogErrorSource = source, LogErrorMethod = method, LogErrorMessage = message });
        }
    }
}
