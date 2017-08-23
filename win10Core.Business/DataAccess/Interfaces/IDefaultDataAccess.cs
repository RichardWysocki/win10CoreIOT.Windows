using System.Collections.Generic;

namespace win10Core.Business.DataAccess.Interfaces
{
    public interface IDefaultDataAccess<T>
    {
        IList<T> Get();

        T Get<T>(int id);

        T Insert(T insert);

        bool Update(T update);

        void Delete(int id);

    }
}
