using System.Collections.Generic;
using win10Core.Business.Standard.Model;

namespace win10Core.Business.Standard.DataAccess.Interface
{

    public interface ICustomerDataAccess
    {
        IList<Customer> Get();

        Customer Get(int id);

        Customer Insert(Customer insert);

        bool Update(Customer update);

        void Delete(int id);
    }
}
