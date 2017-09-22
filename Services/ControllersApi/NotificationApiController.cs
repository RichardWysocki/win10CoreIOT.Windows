using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ServiceContracts;

namespace Services.ControllersApi
{
    public class NotificationApiController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
         [System.Web.Http.HttpGet]
        public Kid GetNewRegisteredGifts(string ID)
        {
            var response = new Kid() {Email = "RichardWysocki@gmail.com"};

            return response;
        }

        // GET: api/NotificationApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NotificationApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NotificationApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/NotificationApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/NotificationApi/5
        public void Delete(int id)
        {
        }
    }
}
