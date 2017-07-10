using System;
using System.Collections.Generic;
using System.Linq;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public class ParentDataAccess : IParentDataAccess
    {
        private readonly IDBContext _db;

        public ParentDataAccess(IDBContext db)
        {
            _db = db;
        }

        public IList<Parent> Get()
        {
            return _db.Parent.ToList();
        }

        public Parent Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("Invalid id Paramter");
            var parent = _db.Parent.SingleOrDefault(c => c.ParentId == id);
            if (parent == null)
                throw new Exception("Error getting Parent record.");
            return parent;
        }

        public Parent Insert(Parent insert)
        {
            _db.Parent.Add(insert);
            _db.SaveChanges();
            return insert;
        }

        public bool Update(Parent update)
        {
            var result = _db.Parent.SingleOrDefault(b => b.ParentId == update.ParentId);
            if (result != null)
            {
                result.Name = update.Name;
                result.Email = update.Email;
                result.FamilyId = update.FamilyId;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public void Delete(int id)
        {
            var parent = Get(id);
            _db.Parent.Remove(parent);
            _db.SaveChanges();
        }
    }
}
