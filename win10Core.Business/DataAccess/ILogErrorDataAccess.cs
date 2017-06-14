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

    public interface ICrudDataAccess
    {
        void Delete(int id);
        IList<T> Get<T>();
        T Get<T>(int id);
        void Insert<T>(T logError);
        void Update<T>(T logError);
    }
}