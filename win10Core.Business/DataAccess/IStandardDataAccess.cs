using System.Collections.Generic;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{

    public interface IStandardDataAccess
    {
        IList<Customer> Get();

        Customer Get(int id);

        void Delete(int id);

        void Update(Customer update);
    }
}
