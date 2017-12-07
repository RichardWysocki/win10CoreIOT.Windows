using win10Core.Business.Model;

namespace win10Core.Business.NETCORE.Engine.Interface
{
    public interface IParentEngine
    {
        Parent InsertParent(Parent insertParent);
        void UpdateParent(Parent updateParent);
        void DeleteParent(int deleteParent);
    }
}
