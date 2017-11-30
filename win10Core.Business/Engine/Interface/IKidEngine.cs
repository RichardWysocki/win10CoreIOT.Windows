using win10Core.Business.Model;

namespace win10Core.Business.Engine.Interface
{
    public interface IKidEngine
    {
        Kid InsertKid(Kid insertkid);
        void UpdateKid(Kid kid);
        void DeleteKid(int v);




    }
}