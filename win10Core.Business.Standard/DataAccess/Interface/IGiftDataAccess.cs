using System.Collections.Generic;
using win10Core.Business.Standard.Model;

namespace win10Core.Business.Standard.DataAccess.Interface
{
    public interface IGiftDataAccess
    {
        IList<Gift> Get();

        Gift Get(int id);

        IEnumerable<Gift> GetEmailList(bool emailSent);

        Gift Insert(Gift insert);

        bool Update(Gift update);

        void Delete(int id);
    }
}
