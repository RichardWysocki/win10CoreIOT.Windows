using System;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Engine.Interface;
using win10Core.Business.Model;

namespace win10Core.Business.Engine
{
    public class ParentEngine: IParentEngine
    {

        private readonly IParentDataAccess _parentDataAccess;
        private readonly IFamilyDataAccess _familyDataAccess;

        public ParentEngine(IParentDataAccess parentDataAccess, IFamilyDataAccess familyDataAccess)
        {
            _familyDataAccess = familyDataAccess;
            _parentDataAccess = parentDataAccess;
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
