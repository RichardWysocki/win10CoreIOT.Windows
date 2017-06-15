using System.Collections.Generic;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public interface ILogInfoDataAccess
    {
        IList<LogInfo> Get();
        LogInfo Get(int id);
        void Insert(LogInfo logInfo);

    }
}