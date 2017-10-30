using System.Collections.Generic;

namespace win10Core.Business.Standard.DataAccess.Interface
{
    public interface IDataAccess
    {  
        IList<T> ReadData<T>(string storedProcedure);
    }
}