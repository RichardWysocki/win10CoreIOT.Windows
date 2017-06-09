using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public class CustomerDataAccess2 : IStandardDataAccess
    {
        private IDBContext db;

        public CustomerDataAccess2(IDBContext dbcontext)
        {
            db = dbcontext;
        }

        public IList<Customer> Get()
        {
            var list = db.customer.ToList();
            return list;
        }

        public Customer Get(int id)
        {
            var customer = db.customer.Where(cust => cust.CustomerId == id).Single();
            return customer;
        }

        public void Delete(int id)
        {
            var customer = Get(id);
            if (customer == null)
                throw new Exception("Can Not Delete as there is No Record here...");
            db.customer.Remove(customer);
            db.SaveChanges();
        }

        public void Update(Customer update)
        {
            var result = db.customer.SingleOrDefault(b => b.CustomerId == update.CustomerId);
            if (result != null)
            {
                result.FirstName = update.FirstName;
                result.LastName = update.LastName;
            }
            db.SaveChanges();
        }

        public void Insert(Customer insert)
        {
            db.customer.Add(insert);
            db.SaveChanges();
        }
    }
}
