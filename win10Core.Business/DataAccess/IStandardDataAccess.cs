using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
