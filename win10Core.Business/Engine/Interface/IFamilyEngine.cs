using win10Core.Business.Model;

namespace win10Core.Business.Engine.Interface
{
    public interface IFamilyEngine
    {
        Family InsertFamily(Family insertFamily);
        void UpdateFamily(Family updateFamily);
        void DeleteFamily(int deleteFamily);
    }
}
