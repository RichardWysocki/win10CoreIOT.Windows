using System.Collections.Generic;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess.Interfaces
{
    public interface ILogErrorDataAccess
    {
        void Delete(int id);
        IList<LogError> Get();
        LogError Get(int id);
        LogError Insert(LogError logError);
        bool Update(LogError logError);
    }
}