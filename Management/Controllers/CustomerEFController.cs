using System.Collections.Generic;
using System.Web.Http;
using ServiceContracts;
using win10Core.Business.DataAccess;
using win10Core.Business.Model;

namespace Management.Controllers
{
    public class CustomerEfController : ApiController
    {
        private readonly CustomerDataAccess clientAccess;

        public CustomerEfController()
        {
             clientAccess = new CustomerDataAccess(new DBContext());
        }
        // GET api/<controller>
        public IEnumerable<Customer> Get()
        {
            var getdata = clientAccess.Get();
            return getdata; 
        }

        // GET api/<controller>/5
        public Customer Get(int id)
        {
            var getdata = clientAccess.Get(id);
            return getdata;
        }

        // POST api/<controller>
        public void Post(Customer customer)
        {
            clientAccess.Insert(customer);
        }

        // PUT api/<controller>/5
        public void Put(int id, Customer customer)
        {
            
            clientAccess.Update(customer);

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

             clientAccess.Delete(id);

        }
    }
}