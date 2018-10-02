using System.Collections.Generic;
using win10Core.Business.Standard.Model;

namespace win10Core.Business.Standard.DataAccess.Interface
{
    public interface IParentDataAccess
    {
        IList<Parent> Get();

        Parent Get(int id);

        List<Parent> GetbyFamily(int familyId);

        Parent Insert(Parent insert);

        bool Update(Parent update);

        void Delete(int id);
    }
}
