using System.Collections.Generic;

namespace ClassLibrary
{
    public interface IDataAccess
    {  
        IList<T> ReadData<T>(string storedProcedure);
    }
}