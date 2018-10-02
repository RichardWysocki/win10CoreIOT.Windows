
using win10Core.Business.Standard.Model;

namespace win10Core.Business.Standard.Engine.Interface
{
    public interface IParentEngine
    {
        Parent InsertParent(Parent insertParent);
        void UpdateParent(Parent updateParent);
        void DeleteParent(int deleteParent);
    }
}
