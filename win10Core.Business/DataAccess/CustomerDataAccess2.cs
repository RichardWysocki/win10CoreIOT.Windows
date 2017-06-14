using System;
using System.Collections.Generic;
using System.Linq;
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
            var list = db.Customer.ToList();
            return list;
        }

        public Customer Get(int id)
        {
            var customer = db.Customer.Where(cust => cust.CustomerId == id).Single();
            return customer;
        }

        public void Delete(int id)
        {
            var customer = Get(id);
            if (customer == null)
                throw new Exception("Can Not Delete as there is No Record here...");
            db.Customer.Remove(customer);
            db.SaveChanges();
        }

        public void Update(Customer update)
        {
            var result = db.Customer.SingleOrDefault(b => b.CustomerId == update.CustomerId);
            if (result != null)
            {
                result.FirstName = update.FirstName;
                result.LastName = update.LastName;
            }
            db.SaveChanges();
        }

        public void Insert(Customer insert)
        {
            db.Customer.Add(insert);
            db.SaveChanges();
        }
    }
}
