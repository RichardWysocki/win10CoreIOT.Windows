using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using win10Core.Business.DataAccess.Interfaces;
using FamilyDTO = ServiceContracts.Contracts.FamilyDTO;

namespace Services.ASPNETCore.Docker.Controllers
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
        public IEnumerable<FamilyDTO> Get()
        {
            var getData = _familyDataAccess.Get();
            var response = getData
                .Select(c => new FamilyDTO() { FamilyId = c.FamilyId, FamilyName = c.FamilyName, FamilyEmail = c.FamilyEmail }).ToList();
            return response;

        }

        // GET: api/FamilyApi/5
        [HttpGet("{id}")]
        public FamilyDTO Get(int id)
        {
            var getData = _familyDataAccess.Get(id);
            var response = new FamilyDTO { FamilyId = getData.FamilyId, FamilyName = getData.FamilyName, FamilyEmail = getData.FamilyEmail };
            return response;
        }

        // POST: api/FamilyApi
        [HttpPost]
        public FamilyDTO Post([FromBody] FamilyDTO family)
        {
            var getData = _familyDataAccess.Insert(new win10Core.Business.Model.Family {FamilyName = family.FamilyName, FamilyEmail = family.FamilyEmail});
            var response = new FamilyDTO { FamilyId = getData.FamilyId, FamilyName = getData.FamilyName, FamilyEmail = getData.FamilyEmail };
            return response;
        }

        // PUT: api/FamilyApi/5
        [HttpPut]
        public void Put([FromBody] FamilyDTO family)
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
