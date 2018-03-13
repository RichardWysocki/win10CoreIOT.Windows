using System;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Engine.Interface;
using win10Core.Business.Model;

namespace win10Core.Business.Engine
{
    public class FamilyEngine: IFamilyEngine
    {

        private readonly IFamilyDataAccess _familyDataAccess;

        public FamilyEngine(IFamilyDataAccess familyDataAccess)
        {
            _familyDataAccess = familyDataAccess;
        }
        public Family InsertFamily(Family insertFamily)
        {
            var family = _familyDataAccess.Get(insertFamily.FamilyId);
            var getData = _familyDataAccess.Insert(insertFamily);
            return getData;
        }

        public void UpdateFamily(Family updateFamily)
        {
            var family = _familyDataAccess.Get(updateFamily.FamilyId);
            _familyDataAccess.Update(updateFamily);
        }

        public void DeleteFamily(int deleteFamily)
        {
            var getKid = _familyDataAccess.Get(deleteFamily);
            _familyDataAccess.Delete(deleteFamily);
        }
    }
}
