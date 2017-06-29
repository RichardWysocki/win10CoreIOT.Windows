using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public class KidDataAccess : IKidDataAccess
    {
        private readonly IDBContext _db;

        public KidDataAccess(IDBContext dbcontext)
        {
            _db = dbcontext;
        }
        public IList<Kid> Get()
        {
            return _db.Kid.ToList();
        }

        public Kid Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("Invalid id Paramter");
            var kid = _db.Kid.SingleOrDefault(c => c.KidId == id);
            if (kid == null)
                throw new Exception("Error getting Kid record.");
            return kid;
        }

        public Kid Insert(Kid insert)
        {
            _db.Kid.Add(insert);
            _db.SaveChanges();
            return insert;
        }

        public bool Update(Kid update)
        {
            var result = _db.Kid.SingleOrDefault(b => b.KidId == update.KidId);
            if (result != null)
            {
                result.Name = update.Name;
                result.Email = update.Email;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public void Delete(int id)
        {
            var kid = Get(id);
            _db.Kid.Remove(kid);
            _db.SaveChanges();
        }
    }
}
