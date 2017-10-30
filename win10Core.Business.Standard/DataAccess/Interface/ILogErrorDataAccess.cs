using System.Collections.Generic;
using win10Core.Business.Standard.Model;

namespace win10Core.Business.Standard.DataAccess.Interface
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