 using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
 using win10Core.Business.DataAccess;
 using win10Core.Business.Model;

namespace Services.Controllers
{
    public class ClientController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Customer> Get()
        {

            
            var clientAccess = new CustomerDataAccess("Data Source=DESKTOP-726BCQD;Initial Catalog=DEV_Build;User ID=WebUser;Password=WebUser1!;MultipleActiveResultSets=True");

            var getdata = clientAccess.ReadData<Customer>("Customer_list").ToList();
            return getdata; //.AsEnumerable();
            //new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}