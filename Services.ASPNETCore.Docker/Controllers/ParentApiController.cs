using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.Contracts;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Engine.Interface;
using win10Core.Business.Model;

namespace Services.ASPNETCore.Docker.Controllers
{
    [Route("api/[controller]")]
    public class ParentApiController : Controller
    {
        private readonly IParentDataAccess _parentDataAccess;
        private readonly ILogEngine _logEngine;

        public ParentApiController(IParentDataAccess parentDataAccess, ILogEngine logEngine)
        {
            _parentDataAccess = parentDataAccess;
            _logEngine = logEngine;
        }

        // GET: api/ParentApi
        [HttpGet]
        public IActionResult Get()
        {
            _logEngine.LogInfo("ParentApiController: /api/ParentApi/Get", "Starting Method");
            var getData = _parentDataAccess.Get();
            var response = getData
                .Select(c => new ParentDTO() { ParentId = c.ParentId, Name = c.Name, Email = c.Email, FamilyId = c.FamilyId}).ToList();
            _logEngine.LogInfo("ParentApiController: /api/ParentApi/Get", "Returning Method");
            return Ok(response);   
        }

        // GET: api/ParentApi/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
             try
            {
                _logEngine.LogInfo($"ParentApiController: /api/ParentApi/Get/{id}", "Starting Method");
                var getData = _parentDataAccess.Get(id);
                var response = new ParentDTO() { ParentId = getData.ParentId, FamilyId = getData.FamilyId, Name = getData.Name, Email = getData.Email };
                _logEngine.LogInfo($"ParentApiController: /api/ParentApi/Get/{id}", "Returning Method");
                return Ok(response);
            }
            catch (Exception e) when (e.Message == "Error getting Family record.")
            {
                _logEngine.LogInfo($"ParentApiController: /api/ParentApi/Get/{id}", "Returning NOTFOUND");
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logEngine.LogError("ParentApiController", $"/api/ParentApi/Get/{id}", e.Message);
                return StatusCode(500, "Unknow Failure: Logged");
            }
        }

        // POST: api/ParentApi
        [HttpPost]
        public IActionResult Post([FromBody] ParentDTO parent)
        {
            _logEngine.LogInfo($"ParentApiController: /api/ParentApi/Post/{parent}", "Starting Method");
            var getData = _parentDataAccess.Insert(new Parent() {Name = parent.Name, Email = parent.Email, FamilyId = parent.FamilyId});
            var response = new ParentDTO { ParentId = getData.ParentId, Name = getData.Name, Email = getData.Email, FamilyId = getData.FamilyId};
            _logEngine.LogInfo($"ParentApiController: /api/ParentApi/Post/{parent}", "Returning Method");
            return Created($"/api/ParentAPI/{response.ParentId}", response);
        }

        // PUT: api/ParentApi/
        [HttpPut]
        public IActionResult Put([FromBody] ParentDTO parent)
        {
            //var getData = _parentDataAccess.Update(new win10Core.Business.Model.Parent() { ParentId = parent.ParentId,  Name = parent.Name, Email = parent.Email, FamilyId = parent.FamilyId});

            _logEngine.LogInfo($"ParentApiController: /api/FamilyApi/Put/{parent}", "Starting Method");
            var getDataUpdate = _parentDataAccess.Update(new Parent() { ParentId = parent.ParentId, Name = parent.Name, Email = parent.Email, FamilyId = parent.FamilyId });
            if (getDataUpdate)
            {
                _logEngine.LogInfo($"ParentApiController: /api/ParentApi/Put/{parent}", "Returning Method");
                return Accepted($"/api/ParentApi/{parent.ParentId}");
            }
            _logEngine.LogInfo($"ParentApiController: /api/ParentApi/Put/{parent}", "Returning NOTFOUND");
            return NotFound();
        }

        // DELETE: api/ParentApi/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logEngine.LogInfo($"ParentApiController: /api/ParentApi/Delete/{id}", "Starting Method");
                _parentDataAccess.Delete(id);
                _logEngine.LogInfo($"ParentApiController: /api/ParentApi/Delete/{id}", "Returning Method");
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logEngine.LogError("ParentApiController", $"/api/ParentApi/Delete/{id}", e.Message);
                _logEngine.LogInfo($"ParentApiController: /api/ParentApi/Delete/{id}", "Returning NOTFOUND");
                return NotFound();
            }
        }
    }
}
