using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ServiceContracts.Contracts;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Engine.Interface;

namespace Services.ControllersApi
{
    public class KidApiController : ApiController
    {
        private readonly IKidDataAccess _kidDataAccess;
        private readonly IKidEngine _kidEngine;

        public KidApiController(IKidDataAccess kidDataAccess, IKidEngine kidEngine)
        {
            _kidDataAccess = kidDataAccess;
            _kidEngine = kidEngine;
        }
        // GET: api/kidApi
        public IEnumerable<KidDTO> Get()
        {
            var getData = _kidDataAccess.Get();
            var response = getData
                .Select(c => new KidDTO() { KidId = c.KidId, Name = c.Name, Email = c.Email, FamilyId = c.FamilyId}).ToList();
            return response;   

        }

        // GET: api/KidApi/5
        public KidDTO Get(int id)
        {
            var getData = _kidDataAccess.Get(id);
            var response = new KidDTO() { KidId = getData.KidId, FamilyId = getData.FamilyId, Name = getData.Name, Email = getData.Email };
            return response;
        }

        // POST: api/KidApi
        public KidDTO Post(KidDTO kid)
        {
            var addKid = new win10Core.Business.Model.Kid() {Name = kid.Name, Email = kid.Email, FamilyId = kid.FamilyId};
            try
            {
                var getData =  _kidEngine.InsertKid(addKid);
                var response = new KidDTO { KidId = getData.KidId, Name = getData.Name, Email = getData.Email, FamilyId = getData.FamilyId };
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // throw new HttpRequestException(e.Message);
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

        }

        // PUT: api/KidApi/5
        public void Put(KidDTO kid)
        {
            try
            {
                _kidEngine.UpdateKid(new win10Core.Business.Model.Kid() { KidId = kid.KidId, Name = kid.Name, Email = kid.Email, FamilyId = kid.FamilyId });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // throw new HttpRequestException(e.Message);
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
         }

        // DELETE: api/KidApi/5
        public void Delete(int id)
        {
            try
            {
                _kidEngine.DeleteKid(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // throw new HttpRequestException(e.Message);
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
