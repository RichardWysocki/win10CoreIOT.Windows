using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.Contracts;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Engine.Interface;
using win10Core.Business.Model;

namespace Services.ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    public class KidApiController : Controller
    {
        private readonly IKidDataAccess _kidDataAccess;
        private readonly ILogEngine _logEngine;

        public KidApiController(IKidDataAccess kidDataAccess, ILogEngine logEngine)
        {
            _kidDataAccess = kidDataAccess;
            _logEngine = logEngine;
        }

        // GET: api/kidApi
        [HttpGet]
        public IActionResult Get()
        {
            _logEngine.LogInfo("KidApiController: /api/KidApi/Get", "Starting Method");
            var getData = _kidDataAccess.Get();
            var response = getData
                .Select(c => new KidDTO() { KidId = c.KidId, Name = c.Name, Email = c.Email, FamilyId = c.FamilyId}).ToList();
            _logEngine.LogInfo("KidApiController: /api/KidApi/Get", "Returning Method");
            return Ok(response);   

        }


        // GET: api/KidApi/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                _logEngine.LogInfo($"KidApiController: /api/KidApi/Get/{id}", "Starting Method");
                var getData = _kidDataAccess.Get(id);
                var response = new KidDTO() { KidId = getData.KidId, FamilyId = getData.FamilyId, Name = getData.Name, Email = getData.Email };
                _logEngine.LogInfo($"KidApiController: /api/KidApi/Get/{id}", "Returning Method");
                return Ok(response);
            }
            catch (Exception e) when (e.Message == "Error getting Family record.")
            {
                _logEngine.LogInfo($"KidApiController: /api/KidApi/Get/{id}", "Returning NOTFOUND");
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logEngine.LogError("KidApiController", $"/api/KidApi/Get/{id}", e.Message);
                return StatusCode(500, "Unknow Failure: Logged");
            }
        }

        // POST: api/KidApi
        [HttpPost]
        public IActionResult Post([FromBody] KidDTO kid)
        {
            _logEngine.LogInfo($"KidApiController: /api/KidApi/Post/{kid}", "Starting Method");
            var getData = _kidDataAccess.Insert(new Kid() {Name = kid.Name, Email = kid.Email, FamilyId = kid.FamilyId});
            var response = new KidDTO { KidId = getData.KidId, Name = getData.Name, Email = getData.Email, FamilyId = getData.FamilyId};
            _logEngine.LogInfo($"KidApiController: /api/KidApi/Post/{kid}", "Returning Method");
            return Created($"/api/KidAPI/{response.KidId}", response);
        }

        // PUT: api/KidApi/5
        [HttpPut]
        public IActionResult Put([FromBody] KidDTO kid)
        {
            

            _logEngine.LogInfo($"KidApiController: /api/FamilyApi/Put/{kid}", "Starting Method");
            var getDataUpdate = _kidDataAccess.Update(new Kid() { KidId = kid.KidId, Name = kid.Name, Email = kid.Email, FamilyId = kid.FamilyId });
            if (getDataUpdate)
            {
                _logEngine.LogInfo($"KidApiController: /api/KidApi/Put/{kid}", "Returning Method");
                return Accepted($"/api/KidApi/{kid.KidId}");
            }
            _logEngine.LogInfo($"KidApiController: /api/KidApi/Put/{kid}", "Returning NOTFOUND");
            return NotFound();
        }

        // DELETE: api/KidApi/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logEngine.LogInfo($"KidApiController: /api/KidApi/Delete/{id}", "Starting Method");
                _kidDataAccess.Delete(id);
                _logEngine.LogInfo($"KidApiController: /api/KidApi/Delete/{id}", "Returning Method");
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logEngine.LogError("KidApiController", $"/api/KidApi/Delete/{id}", e.Message);
                _logEngine.LogInfo($"KidApiController: /api/KidApi/Delete/{id}", "Returning NOTFOUND");
                return NotFound();
            }
        }
    }
}
