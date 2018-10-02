using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.Contracts;
using win10Core.Business.Standard.DataAccess.Interface;
using win10Core.Business.Standard.Engine.Interface;

namespace Services.ASPNETCore.Docker.Controllers
{
    [Route("api/[controller]")]
    public class FamilyApiController : Controller
    {
        private readonly IFamilyDataAccess _familyDataAccess;
        private readonly ILogEngine _logEngine;

        public FamilyApiController(IFamilyDataAccess familyDataAccess, ILogEngine logEngine)
        {
            _familyDataAccess = familyDataAccess;
            _logEngine = logEngine;
        }

        // GET: api/FamilyApi
        [HttpGet]
        public IActionResult Get()
        {
            _logEngine.LogInfo("FamilyApiController: /api/FamilyApi/Get", "Starting Method");
            var getData = _familyDataAccess.Get();
            var response = getData
                .Select(c => new FamilyDTO() { FamilyId = c.FamilyId, FamilyName = c.FamilyName, FamilyEmail = c.FamilyEmail }).ToList();
            _logEngine.LogInfo("FamilyApiController: /api/FamilyApi/Get", "Returning Method");
            return Ok(response);
        }

        // GET: api/FamilyApi/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                _logEngine.LogInfo($"FamilyApiController: /api/FamilyApi/Get/{id}", "Starting Method");
                var getData = _familyDataAccess.Get(id);
                var response = new FamilyDTO { FamilyId = getData.FamilyId, FamilyName = getData.FamilyName, FamilyEmail = getData.FamilyEmail };
                _logEngine.LogInfo($"FamilyApiController: /api/FamilyApi/Get/{id}", "Returning Method");
                return Ok(response);
            }
            catch (Exception e) when (e.Message == "Error getting Family record.")
            {
                _logEngine.LogInfo($"FamilyApiController: /api/FamilyApi/Get/{id}", "Returning NOTFOUND");
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logEngine.LogError("FamilyApiController", $"/api/FamilyApi/Get/{id}",e.Message);
                return StatusCode(500, "Unknow Failure: Logged");
            }
        }

        // POST: api/FamilyApi
        [HttpPost]
        public IActionResult Post([FromBody] FamilyDTO family)
        {
            _logEngine.LogInfo($"FamilyApiController: /api/FamilyApi/Post/{family}", "Starting Method");
            var getData = _familyDataAccess.Insert(new win10Core.Business.Standard.Model.Family {FamilyName = family.FamilyName, FamilyEmail = family.FamilyEmail});
            var response = new FamilyDTO { FamilyId = getData.FamilyId, FamilyName = getData.FamilyName, FamilyEmail = getData.FamilyEmail };
            _logEngine.LogInfo($"FamilyApiController: /api/FamilyApi/Post/{family}", "Returning Method");
            return Created($"/api/FamilyAPI/{response.FamilyId}" , response);
        }

        // PUT: api/FamilyApi/5
        [HttpPut]
        public IActionResult Put([FromBody] FamilyDTO family)
        {
            _logEngine.LogInfo($"FamilyApiController: /api/FamilyApi/Put/{family}", "Starting Method");
            var getDataUpdate = _familyDataAccess.Update(new win10Core.Business.Standard.Model.Family { FamilyId = family.FamilyId, FamilyName = family.FamilyName, FamilyEmail = family.FamilyEmail });
            if (getDataUpdate)
            {
                _logEngine.LogInfo($"FamilyApiController: /api/FamilyApi/Put/{family}", "Returning Method");
                return Accepted($"/api/FamilyApi/{family.FamilyId}");
            }
            _logEngine.LogInfo($"FamilyApiController: /api/FamilyApi/Put/{family}", "Returning NOTFOUND");
            return NotFound();
        }

        // DELETE: api/FamilyApi/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //TODO  //Only Delete if Parent is not using the FamilyID
            try
            {
                _logEngine.LogInfo($"FamilyApiController: /api/FamilyApi/Delete/{id}", "Starting Method");
                _familyDataAccess.Delete(id);
                _logEngine.LogInfo($"FamilyApiController: /api/FamilyApi/Delete/{id}", "Returning Method");
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logEngine.LogError("FamilyApiController", $"/api/FamilyApi/Delete/{id}", e.Message);
                _logEngine.LogInfo($"FamilyApiController: /api/FamilyApi/Delete/{id}", "Returning NOTFOUND");
                return NotFound();
            }
            

        }
    }
}
