using System;
using System.Collections.Generic;
using System.Linq;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
        private readonly IDBContext _db;

        public CustomerDataAccess(IDBContext dbcontext)
        {
            _db = dbcontext;
        }

        public IList<Customer> Get()
        {
            var list = _db.Customer.ToList();
            return list;
        }

        public Customer Get(int id)
        {
            var customer = _db.Customer.Where(cust => cust.CustomerId == id).Single();
            return customer;
        }

        public void Delete(int id)
        {
            var customer = Get(id);
            if (customer == null)
                throw new Exception("Can Not Delete as there is No Record here...");
            _db.Customer.Remove(customer);
            _db.SaveChanges();
        }

        public bool Update(Customer update)
        {
            var result = _db.Customer.SingleOrDefault(b => b.CustomerId == update.CustomerId);
            if (result != null)
            {
                result.FirstName = update.FirstName;
                result.LastName = update.LastName;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public Customer Insert(Customer insert)
        {
            _db.Customer.Add(insert);
            _db.SaveChanges();
            return insert;
        }
    }
}
