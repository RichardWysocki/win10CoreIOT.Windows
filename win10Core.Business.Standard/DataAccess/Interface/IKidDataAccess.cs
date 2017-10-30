using System.Collections.Generic;
using win10Core.Business.Standard.Model;

namespace win10Core.Business.Standard.DataAccess.Interface
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
