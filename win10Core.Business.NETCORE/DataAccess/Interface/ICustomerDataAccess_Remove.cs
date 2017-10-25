using System.Collections.Generic;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess.Interfaces
{
    public interface ICustomerDataAccessRemove
    {
        bool Delete(int deleteId);
        bool Insert(Customer customer);
        IList<T> ReadData<T>(string storedProcedure);
        bool Update(Customer updateCustomer);
    }
}