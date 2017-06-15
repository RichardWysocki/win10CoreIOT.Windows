using System.Collections.Generic;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public interface ILogErrorDataAccess
    {
        void Delete(int id);
        IList<LogError> Get();
        LogError Get(int id);
        void Insert(LogError logError);
        void Update(LogError logError);
    }
}