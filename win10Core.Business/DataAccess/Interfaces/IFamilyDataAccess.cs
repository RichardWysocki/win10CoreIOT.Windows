using System.Collections.Generic;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess.Interfaces
{
    public interface IFamilyDataAccess
    {
            IList<Family> Get();

            Family Get(int id);

            Family Insert(Family insert);

            bool Update(Family update);

            void Delete(int id);
    }
}
