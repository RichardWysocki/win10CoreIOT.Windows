
using win10Core.Business.Standard.DataAccess.Interface;
using win10Core.Business.Standard.Engine.Interface;
using win10Core.Business.Standard.Model;

namespace win10Core.Business.NETCORE.Engine
{
    public class ParentEngine: IParentEngine
    {

        private readonly IParentDataAccess _parentDataAccess;
        private readonly IFamilyDataAccess _familyDataAccess;

        public ParentEngine(IFamilyDataAccess familyDataAccess, IParentDataAccess ParentDataAccess)
        {
            _familyDataAccess = familyDataAccess;
            _parentDataAccess = ParentDataAccess;
        }
        public Parent InsertParent(Parent insertParent)
        {
            var family = _familyDataAccess.Get(insertParent.FamilyId);
            var getData = _parentDataAccess.Insert(insertParent);
            return getData;
        }

        public void UpdateParent(Parent updateParent)
        {
            var family = _familyDataAccess.Get(updateParent.FamilyId);
            _parentDataAccess.Update(updateParent);
        }

        public void DeleteParent(int deleteParent)
        {
            var getKid = _parentDataAccess.Get(deleteParent);
            _parentDataAccess.Delete(deleteParent);
        }
    }
}
