﻿using System;
using System.Net;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Engine.Interface;
using win10Core.Business.Model;

namespace win10Core.Business.Engine
{
    public class KidEngine : IKidEngine
    {
        private readonly IKidDataAccess _kidDataAccess;
        private readonly IFamilyDataAccess _familyDataAccess;

        public KidEngine(IFamilyDataAccess familyDataAccess, IKidDataAccess kidDataAccess)
        {
            _familyDataAccess = familyDataAccess;
            _kidDataAccess = kidDataAccess;
        }

        public Kid InsertKid(Kid insertkid)
        {
            var family = _familyDataAccess.Get(insertkid.FamilyId);
            var getData = _kidDataAccess.Insert(insertkid);
            return getData;
        }

        public void DeleteKid(int kidID)
        {
            var getKid = _kidDataAccess.Get(kidID);
            _kidDataAccess.Delete(kidID);
        }

        public void UpdateKid(Kid kid)
        {
            var family = _familyDataAccess.Get(kid.FamilyId);
            _kidDataAccess.Update(kid);
        }


    }
}
