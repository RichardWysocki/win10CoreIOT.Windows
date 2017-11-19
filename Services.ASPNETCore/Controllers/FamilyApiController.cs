using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using win10Core.Business.DataAccess.Interfaces;
using Family = ServiceContracts.Contracts.Family;

namespace Services.ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    public class FamilyApiController : Controller
    {
        private readonly IFamilyDataAccess _familyDataAccess;

        public FamilyApiController(IFamilyDataAccess familyDataAccess)
        {
            _familyDataAccess = familyDataAccess;
        }
        // GET: api/FamilyApi
        [HttpGet]
        public IEnumerable<Family> Get()
        {
            var getData = _familyDataAccess.Get();
            var response = getData
                .Select(c => new Family() { FamilyId = c.FamilyId, FamilyName = c.FamilyName, FamilyEmail = c.FamilyEmail }).ToList();
            return response;

        }

        // GET: api/FamilyApi/5
        [HttpGet("{id}")]
        public Family Get(int id)
        {
            var getData = _familyDataAccess.Get(id);
            var response = new Family { FamilyId = getData.FamilyId, FamilyName = getData.FamilyName, FamilyEmail = getData.FamilyEmail };
            return response;
        }

        // POST: api/FamilyApi
        [HttpPost]
        public Family Post([FromBody] Family family)
        {
            var getData = _familyDataAccess.Insert(new win10Core.Business.Model.Family {FamilyName = family.FamilyName, FamilyEmail = family.FamilyEmail});
            var response = new Family { FamilyId = getData.FamilyId, FamilyName = getData.FamilyName, FamilyEmail = getData.FamilyEmail };
            return response;
        }

        // PUT: api/FamilyApi/5
        [HttpPut]
        public void Put([FromBody] Family family)
        {
            var getData = _familyDataAccess.Update(new win10Core.Business.Model.Family { FamilyId = family.FamilyId, FamilyName = family.FamilyName, FamilyEmail = family.FamilyEmail });
        }

        // DELETE: api/FamilyApi/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //TODO  //Only Delete if Parent is not using the FamilyID
            _familyDataAccess.Delete(id);

        }
    }
}
