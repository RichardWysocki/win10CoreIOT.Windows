using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Contracts;
using win10Core.Business.DataAccess;

namespace Services.Controllers
{
    public class LogInfoController : ApiController
    {
        private readonly LogInfoDataAccess _logInfoDataAccess;

        public LogInfoController()
        {
             _logInfoDataAccess = new LogInfoDataAccess(new DBContext());
        }
        // GET api/<controller>
        public IEnumerable<LogInfo> Get()
        {
            var getData = _logInfoDataAccess.Get();
            var response = getData
                .Select(c => new LogInfo {LogInfoId = c.LogInfoId, Method = c.Method, Message = c.Message}).ToList();
            return response; 
        }

        // GET api/<controller>/5
        public LogInfo Get(int id)
        {
            var getData = _logInfoDataAccess.Get(id);
            var response = new LogInfo { LogInfoId = getData.LogInfoId, Method = getData.Method, Message = getData.Message };
            return response;
        }

        // POST api/<controller>
        public void Post(LogInfo customer)
        {
            _logInfoDataAccess.Insert(new win10Core.Business.Model.LogInfo { LogInfoId = customer.LogInfoId, Method = customer.Method, Message = customer.Message });
        }


    }
}