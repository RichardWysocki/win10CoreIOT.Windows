using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ServiceContracts.Contracts;
using win10Core.Business.DataAccess.Interfaces;

namespace Services.ControllersApi
{
    public class GiftApiController : ApiController
    {
        private IGiftDataAccess _giftDataAccess;

        public GiftApiController(IGiftDataAccess giftDataAccess)
        {
            _giftDataAccess = giftDataAccess;
        }

        // GET: api/GiftApi
        public IEnumerable<Gift> Get()
        {
            var getData = _giftDataAccess.Get();
            var response = getData
                .Select(c => new Gift() { GiftId = c.GiftId, GiftName = c.GiftName, Priority = c.Priority, WebUrl = c.WebUrl, KidId = c.KidId}).ToList();
            return response;
        }

        // GET: api/GiftApi/5
        public Gift Get(int id)
        {
            var getData = _giftDataAccess.Get(id);
            var response = new Gift() { GiftId = getData.GiftId, GiftName = getData.GiftName, Priority = getData.Priority, WebUrl = getData.WebUrl, KidId = getData.KidId };
            return response;
        }

        // POST: api/GiftApi
        public Gift Post(Gift gift)
        {
            var getData = _giftDataAccess.Insert(new win10Core.Business.Model.Gift { GiftName = gift.GiftName, Priority = gift.Priority, WebUrl = gift.WebUrl, KidId = gift.KidId });
            var response = new Gift { GiftId = getData.GiftId, GiftName = getData.GiftName, Priority = getData.Priority, WebUrl = getData.WebUrl, KidId = getData.KidId };
            return response;
        }

        // PUT: api/GiftApi/5
        public void Put(Gift gift)
        {
            var getData = _giftDataAccess.Update(new win10Core.Business.Model.Gift { GiftId = gift.GiftId, GiftName = gift.GiftName, Priority = gift.Priority, WebUrl = gift.WebUrl, KidId = gift.KidId });
        }

        // DELETE: api/GiftApi/5
        public void Delete(int id)
        {
            _giftDataAccess.Delete(id);
        }
    }
}
