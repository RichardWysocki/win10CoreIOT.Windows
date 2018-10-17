using System.Collections.Generic;
using win10Core.Business.Standard.Model;

namespace win10Core.Business.Standard.DataAccess.Interface
{
    public interface IFamilyDataAccess
    {
            IList<Family> Get();

            Family Get(int id);

            Family GetbyEmailAddress(string emailAddress);

            Family Insert(Family insert);

            bool Update(Family update);

            void Delete(int id);
    }
}
