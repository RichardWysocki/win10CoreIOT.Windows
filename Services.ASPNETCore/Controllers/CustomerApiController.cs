using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using win10Core.Business;
using win10Core.Business.DataAccess;
using win10Core.Business.Model;

namespace Services.ControllersApi
{
    public class CustomerApiController : Controller
    {
        private readonly CustomerDataAccess_Remove _clientAccess;

        public CustomerApiController()
        {
             _clientAccess = new CustomerDataAccess_Remove(ConfigHelper.GetSetting("DBConnection"));
        }
        // GET api/<controller>
        public IEnumerable<Customer> Get()
        {


            var getdata = _clientAccess.ReadData<Customer>("Customer_List").ToList();
            return getdata; 
        }

        // GET api/<controller>/5
        public Customer Get(int id)
        {
            DBContext db = new DBContext();

            var list = db.Customer.ToList();
            foreach (var VARIABLE in list)
            {
                Console.WriteLine(VARIABLE.CustomerId);
            }

            var getdata = _clientAccess.ReadData<Customer>("Customer_List").Where(c => c.CustomerId == id).Single();
            return getdata;
        }

        // POST api/<controller>
        public void Post(Customer customer)
        {
            var getdata = _clientAccess.Insert(customer);
        }

        // PUT api/<controller>/5
        public void Put(int id, Customer customer)
        {
            
            var getdata = _clientAccess.Update(customer);

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

             _clientAccess.Delete(id);

        }
    }
}