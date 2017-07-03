using System;
using System.Collections.Generic;
using System.Linq;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public class FamilyDataAccess : IFamilyDataAccess
    {

        private readonly IDBContext _db;

        public FamilyDataAccess(IDBContext dbcontext)
        {
            _db = dbcontext;
        }

        public IList<Family> Get()
        {
            return _db.Family.ToList();
        }

        public Family Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("Invalid id Paramter");
            var family = _db.Family.SingleOrDefault(c => c.FamilyId == id);
            if (family == null)
                throw new Exception("Error getting Family record.");
            return family;
        }

        public Family Insert(Family insert)
        {
            _db.Family.Add(insert);
            _db.SaveChanges();
            return insert;
        }

        public bool Update(Family update)
        {
            var result = _db.Family.SingleOrDefault(b => b.FamilyId == update.FamilyId);
            if (result != null)
            {
                result.FamilyName = update.FamilyName;
                result.FamilyEmail = update.FamilyEmail;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public void Delete(int id)
        {
            var family = Get(id);
            _db.Family.Remove(family);
            _db.SaveChanges();
        }
    }
}
