using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.Contracts;
using win10Core.Business.Model;
using win10Core.Business.DataAccess;

namespace Services.ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly LogInfoDataAccess _logInfoDataAccess;

        public ValuesController(DBContext myContext)
        {
            _logInfoDataAccess = new LogInfoDataAccess(myContext);
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            DateTime start = DateTime.Now;
            var getData = _logInfoDataAccess.Get();
            var response = getData
                .Select(c => new LogInformation { LogInfoId = c.LogInfoId, Method = c.Method, Message = c.Message })
                .ToList();
            //return response;
            var returnList = new List<string>();
            foreach (var item in response)
            {
                returnList.Add(item.LogInfoId.ToString());
                returnList.Add(item.Method);
                returnList.Add(item.Message);
            }

            DateTime end = DateTime.Now;
            TimeSpan duration = end - start;
            Console.WriteLine(duration.ToString());
            var getInsertData = _logInfoDataAccess.Insert(new LogInfo
            {
                //LogInfoId = log.LogInfoId,
                Method = "ValuesController: Get",
                Message = "Time to Run: " + duration.ToString() + "on" + DateTime.Now.ToString("MM/dd/yyyy")
            });
            return returnList ; // new string[] { "value1", "value2", "value3" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
