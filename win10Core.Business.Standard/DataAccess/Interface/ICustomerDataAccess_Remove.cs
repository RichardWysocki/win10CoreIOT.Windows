using System.Collections.Generic;
using win10Core.Business.Standard.Model;

namespace win10Core.Business.Standard.DataAccess.Interface
{
    public interface ICustomerDataAccessRemove
    {
        bool Delete(int deleteId);
        bool Insert(Customer customer);
        IList<T> ReadData<T>(string storedProcedure);
        bool Update(Customer updateCustomer);
    }
}