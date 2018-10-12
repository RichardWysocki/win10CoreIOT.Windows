using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.Contracts;
using win10Core.Business.Standard.DataAccess.Interface;
using win10Core.Business.Standard.Engine.Interface;
using win10Core.Business.Standard.Model;

namespace Services.ASPNETCore.Docker.Controllers
{
    [Route("api/[controller]")]
    public class LogInfoController : Controller
    {
        private readonly ILogInfoDataAccess _logInfoDataAccess;
        private readonly ILogEngine _logEngine;

        public LogInfoController(ILogEngine logEngine, ILogInfoDataAccess logInfoDataAccess)
        {
            _logEngine = logEngine;
            _logInfoDataAccess = logInfoDataAccess; 
        }

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<LogInformation> Get()
        {
            //_logEngine.LogError("1", "2", "3");
            //_logEngine.LogInfo("1", "2");

            var getData = _logInfoDataAccess.Get();
            var response = getData
                .Select(c => new LogInformation {LogInfoId = c.LogInfoId, Method = c.Method, Message = c.Message})
                .ToList();
            return response;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public LogInformation Get(int id)
        {
            try
            {
                var getData = _logInfoDataAccess.Get(id);
                var response = new LogInformation
                {
                    LogInfoId = getData.LogInfoId,
                    Method = getData.Method,
                    Message = getData.Message
                };
                return response;
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message); 
            }
        }

        // POST api/<controller>
        [HttpPost]
        public LogInformation Post([FromBody] LogInformation log)
        {
            var getData = _logInfoDataAccess.Insert(new LogInfo
            {
                LogInfoId = log.LogInfoId,
                Method = log.Method,
                Message = log.Message
            });
            var response = new LogInformation
            {
                LogInfoId = getData.LogInfoId,
                Method = getData.Method,
                Message = getData.Message
            };
            return response;
        }
    }
}