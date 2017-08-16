﻿using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using win10Core.Business.DataAccess;
using Family = ServiceContracts.Family;

namespace Services.ControllersApi
{
    public class FamilyApiController : ApiController
    {
        private readonly IFamilyDataAccess _familyDataAccess;

        public FamilyApiController(IFamilyDataAccess familyDataAccess)
        {
            _familyDataAccess = familyDataAccess;
        }
        // GET: api/FamilyApi
        public IEnumerable<Family> Get()
        {
            var getData = _familyDataAccess.Get();
            var response = getData
                .Select(c => new Family() { FamilyId = c.FamilyId, FamilyName = c.FamilyName, FamilyEmail = c.FamilyEmail }).ToList();
            return response;

        }

        // GET: api/FamilyApi/5
        public Family Get(int id)
        {
            var getData = _familyDataAccess.Get(id);
            var response = new Family { FamilyId = getData.FamilyId, FamilyName = getData.FamilyName, FamilyEmail = getData.FamilyEmail };
            return response;
        }

        // POST: api/FamilyApi
        public Family Post(Family family)
        {
            var getData = _familyDataAccess.Insert(new win10Core.Business.Model.Family {FamilyName = family.FamilyName, FamilyEmail = family.FamilyEmail});
            var response = new Family { FamilyId = getData.FamilyId, FamilyName = getData.FamilyName, FamilyEmail = getData.FamilyEmail };
            return response;
        }

        // PUT: api/FamilyApi/5
        public void Put(Family family)
        {
            var getData = _familyDataAccess.Update(new win10Core.Business.Model.Family { FamilyId = family.FamilyId, FamilyName = family.FamilyName, FamilyEmail = family.FamilyEmail });
        }

        // DELETE: api/FamilyApi/5
        public void Delete(int id)
        {
            _familyDataAccess.Delete(id);

        }
    }
}