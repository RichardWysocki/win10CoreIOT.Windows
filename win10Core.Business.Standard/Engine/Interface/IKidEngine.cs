
using win10Core.Business.Standard.Model;

namespace win10Core.Business.Standard.Engine.Interface
{
    public interface IKidEngine
    {
        Kid InsertKid(Kid insertkid);
        void UpdateKid(Kid updatekid);
        void DeleteKid(int deleteKid);
    }
}