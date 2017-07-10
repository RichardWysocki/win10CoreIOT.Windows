using System.Collections.Generic;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public interface IParentDataAccess
    {
        IList<Parent> Get();

        Parent Get(int id);

        Parent Insert(Parent insert);

        bool Update(Parent update);

        void Delete(int id);
    }
}
