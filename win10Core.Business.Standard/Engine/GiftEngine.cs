﻿using win10Core.Business.Standard.DataAccess.Interface;
using win10Core.Business.Standard.Engine.Interface;
using win10Core.Business.Standard.Model;

namespace win10Core.Business.NETCORE.Engine
{
    public class GiftEngine : IGiftEngine
    {
        private readonly IKidDataAccess _kidDataAccess;
        private readonly IGiftDataAccess _giftDataAccess;

        public GiftEngine(IGiftDataAccess giftDataAccess, IKidDataAccess kidDataAccess)
        {
            _giftDataAccess = giftDataAccess;
            _kidDataAccess = kidDataAccess;
        }

        public Gift InsertGift(Gift insertGift)
        {
            var kid = _kidDataAccess.Get(insertGift.KidId);
            var getData = _giftDataAccess.Insert(insertGift);
            return getData;
        }

        public void UpdateGift(Gift updateGift)
        {
            var family = _kidDataAccess.Get(updateGift.KidId);
            _giftDataAccess.Update(updateGift);
        }

        public void DeleteGift(int deleteGiftId)
        {
            var getGift = _giftDataAccess.Get(deleteGiftId);
            _giftDataAccess.Delete(deleteGiftId);
        }
    }
}
