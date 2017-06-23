using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Contracts;
using win10Core.Business.DataAccess;
using win10Core.Business.Engine;

namespace Services.ControllersApi
{
    public class LogInfoController : ApiController
    {
        private readonly ILogInfoDataAccess _logInfoDataAccess;
        private readonly ILogEngine _logEngine;

        public LogInfoController(ILogEngine logEngine, ILogInfoDataAccess logInfoDataAccess)
        {
            _logEngine = logEngine;
            _logInfoDataAccess = logInfoDataAccess; //new LogInfoDataAccess(new DBContext());
        }
        // GET api/<controller>
        public IEnumerable<LogInfo> Get()
        {
            _logEngine.LogError("1","2","3");
            _logEngine.LogInfo("1", "2");


            var getData = _logInfoDataAccess.Get();
            var response = getData
                .Select(c => new LogInfo {LogInfoId = c.LogInfoId, Method = c.Method, Message = c.Message}).ToList();
            return response; 
        }

        // GET api/<controller>/5
        public LogInfo Get(int id)
        {
            try
            {


            var getData = _logInfoDataAccess.Get(id);
            var response = new LogInfo { LogInfoId = getData.LogInfoId, Method = getData.Method, Message = getData.Message };
            return response;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message));
            }
        }

        // POST api/<controller>
        public LogInfo Post(LogInfo customer)
        {
            var getData = _logInfoDataAccess.Insert(new win10Core.Business.Model.LogInfo { LogInfoId = customer.LogInfoId, Method = customer.Method, Message = customer.Message });
            var response = new LogInfo { LogInfoId = getData.LogInfoId, Method = getData.Method, Message = getData.Message };
            return response;

        }


    }
}