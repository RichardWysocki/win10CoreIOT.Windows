using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
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
