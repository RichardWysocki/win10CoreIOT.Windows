using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.Contracts;
using win10Core.Business.DataAccess.Interfaces;

namespace Services.ASPNETCore.Docker.Controllers
{
    [Route("api/[controller]")]
    public class GiftApiController : Controller
    {
        private IGiftDataAccess _giftDataAccess;

        public GiftApiController(IGiftDataAccess giftDataAccess)
        {
            _giftDataAccess = giftDataAccess;
        }

        // GET: api/GiftApi
        [HttpGet]
        public IEnumerable<GiftDTO> Get()
        {
            var getData = _giftDataAccess.Get();
            var response = getData
                .Select(c => new GiftDTO() { GiftId = c.GiftId, GiftName = c.GiftName, Priority = c.Priority, WebUrl = c.WebUrl, KidId = c.KidId}).ToList();
            return response;
        }

        // GET: api/GiftApi/5
        [HttpGet("{id}")]
        public GiftDTO Get(int id)
        {
            var getData = _giftDataAccess.Get(id);
            var response = new GiftDTO() { GiftId = getData.GiftId, GiftName = getData.GiftName, Priority = getData.Priority, WebUrl = getData.WebUrl, KidId = getData.KidId };
            return response;
        }

        // POST: api/GiftApi
        [HttpPost]
        public GiftDTO Post([FromBody] GiftDTO gift)
        {
            var getData = _giftDataAccess.Insert(new win10Core.Business.Model.Gift { GiftName = gift.GiftName, Priority = gift.Priority, WebUrl = gift.WebUrl, KidId = gift.KidId });
            var response = new GiftDTO { GiftId = getData.GiftId, GiftName = getData.GiftName, Priority = getData.Priority, WebUrl = getData.WebUrl, KidId = getData.KidId };
            return response;
        }

        // PUT: api/GiftApi/5
        [HttpPut]
        public void Put([FromBody] GiftDTO gift)
        {
            var getData = _giftDataAccess.Update(new win10Core.Business.Model.Gift { GiftId = gift.GiftId, GiftName = gift.GiftName, Priority = gift.Priority, WebUrl = gift.WebUrl, KidId = gift.KidId });
        }

        // DELETE: api/GiftApi/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _giftDataAccess.Delete(id);
        }
    }
}
