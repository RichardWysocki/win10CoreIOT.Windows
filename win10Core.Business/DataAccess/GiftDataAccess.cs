﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public class GiftDataAccess : IGiftDataAccess
    {
        private readonly IDBContext _db;

        public GiftDataAccess(IDBContext db)
        {
            _db = db;
        }
        public IList<Gift> Get()
        {
            return _db.Gift.ToList();
        }

        public Gift Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("Invalid id Paramter");
            var gift = _db.Gift.SingleOrDefault(c => c.KidId == id);
            if (gift == null)
                throw new Exception("Error getting Gift record.");
            return gift;
        }

        public Gift Insert(Gift insert)
        {
            _db.Gift.Add(insert);
            _db.SaveChanges();
            return insert;
        }

        public bool Update(Gift update)
        {
            var result = _db.Gift.SingleOrDefault(b => b.GiftId == update.GiftId);
            if (result != null)
            {
                result.KidId = update.KidId;
                result.GiftName = update.GiftName;
                result.Priority = update.Priority;
                result.WebUrl = update.WebUrl;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public void Delete(int id)
        {
            var gift = Get(id);
            _db.Gift.Remove(gift);
            _db.SaveChanges();
        }
    }
}