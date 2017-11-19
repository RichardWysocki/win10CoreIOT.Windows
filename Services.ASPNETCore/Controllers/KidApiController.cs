using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.Contracts;
using win10Core.Business.DataAccess.Interfaces;

namespace Services.ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    public class KidApiController : Controller
    {
        private readonly IKidDataAccess _kidDataAccess;

        public KidApiController(IKidDataAccess kidDataAccess)
        {
            _kidDataAccess = kidDataAccess;
        }

        // GET: api/kidApi
        [HttpGet]
        public IEnumerable<Kid> Get()
        {
            var getData = _kidDataAccess.Get();
            var response = getData
                .Select(c => new Kid() { KidId = c.KidId, Name = c.Name, Email = c.Email, FamilyId = c.FamilyId}).ToList();
            return response;   

        }


        // GET: api/KidApi/5
        [HttpGet("{id}")]
        public Kid Get(int id)
        {
            var getData = _kidDataAccess.Get(id);
            var response = new Kid() { KidId = getData.KidId, FamilyId = getData.FamilyId, Name = getData.Name, Email = getData.Email };
            return response;
        }

        // POST: api/KidApi
        [HttpPost]
        public Kid Post([FromBody] Kid kid)
        {
            var getData = _kidDataAccess.Insert(new win10Core.Business.Model.Kid() {Name = kid.Name, Email = kid.Email, FamilyId = kid.FamilyId});
            var response = new Kid { KidId = getData.KidId, Name = getData.Name, Email = getData.Email, FamilyId = getData.FamilyId};
            return response;
        }

        // PUT: api/KidApi/5
        [HttpPut]
        public void Put([FromBody] Kid kid)
        {
            var getData = _kidDataAccess.Update(new win10Core.Business.Model.Kid() { KidId = kid.KidId,  Name = kid.Name, Email = kid.Email, FamilyId = kid.FamilyId});
         }

        // DELETE: api/KidApi/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
