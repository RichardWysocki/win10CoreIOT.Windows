
using win10Core.Business.Standard.Model;

namespace win10Core.Business.Standard.Engine.Interface
{
    public interface IFamilyEngine
    {
        Family InsertFamily(Family insertFamily);
        void UpdateFamily(Family updateFamily);
        void DeleteFamily(int deleteFamily);
    }
}
