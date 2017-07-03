using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public interface IGiftDataAccess
    {
        IList<Gift> Get();

        Gift Get(int id);

        Gift Insert(Gift insert);

        bool Update(Gift update);

        void Delete(int id);
    }
}
