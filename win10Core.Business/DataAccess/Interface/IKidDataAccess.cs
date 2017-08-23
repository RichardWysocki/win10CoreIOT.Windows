using System.Collections.Generic;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess.Interfaces
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
