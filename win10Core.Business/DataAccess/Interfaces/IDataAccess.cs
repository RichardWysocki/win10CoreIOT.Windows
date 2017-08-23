using System.Collections.Generic;

namespace win10Core.Business.DataAccess.Interfaces
{
    public interface IDataAccess
    {  
        IList<T> ReadData<T>(string storedProcedure);
    }
}