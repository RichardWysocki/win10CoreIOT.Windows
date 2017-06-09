using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using win10Core.Business;
using win10Core.Business.DataAccess;
using win10Core.Business.Model;

namespace Services.Controllers
{
    public class CustomerController : ApiController
    {
        private CustomerDataAccess clientAccess;

        public CustomerController()
        {
             clientAccess = new CustomerDataAccess(ConfigHelper.GetSetting("DBConnection"));
        }
        // GET api/<controller>
        public IEnumerable<Customer> Get()
        {


            var getdata = clientAccess.ReadData<Customer>("Customer_List").ToList();
            return getdata; 
        }

        // GET api/<controller>/5
        public Customer Get(int id)
        {
            DBContext db = new DBContext();

            var list = db.customer.ToList();
            foreach (var VARIABLE in list)
            {
                Console.WriteLine(VARIABLE.CustomerId);
            }

            var getdata = clientAccess.ReadData<Customer>("Customer_List").Where(c => c.CustomerId == id).Single();
            return getdata;
        }

        // POST api/<controller>
        public void Post(Customer customer)
        {
            var getdata = clientAccess.Insert(customer);
        }

        // PUT api/<controller>/5
        public void Put(int id, Customer customer)
        {
            
            var getdata = clientAccess.Update(customer);

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

             clientAccess.Delete(id);

        }
    }
}