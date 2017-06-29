using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public interface IKidDataAccess
    {
        IList<Kid> Get();

        Kid Get(int id);

        Kid Insert(Kid insert);

        bool Update(Kid update);

        void Delete(int id);

    }
}
