using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.Contracts;
using win10Core.Business.Standard.DataAccess.Interface;
using win10Core.Business.Standard.Engine.Interface;
using win10Core.Business.Standard.Model;

namespace Services.ASPNETCore.Docker.Controllers
{
    [Route("api/[controller]")]
    public class GiftApiController : Controller
    {
        private readonly IGiftDataAccess _giftDataAccess;
        private readonly ILogEngine _logEngine;

        public GiftApiController(IGiftDataAccess giftDataAccess, ILogEngine logEngine)
        {
            _giftDataAccess = giftDataAccess;
            _logEngine = logEngine;

        }

        // GET: api/GiftApi
        [HttpGet]
        public IActionResult Get()
        {
            _logEngine.LogInfo("GiftApiController: /api/GiftApi/Get", "Starting Method");
            var getData = _giftDataAccess.Get();
            var response = getData
                .Select(c => new GiftDTO() { GiftId = c.GiftId, GiftName = c.GiftName, Priority = c.Priority, WebUrl = c.WebUrl, KidId = c.KidId}).ToList();
            _logEngine.LogInfo("GiftApiController: /api/GiftApi/Get", "Returning Method");
            return Ok(response);
        }

        // GET: api/GiftApi/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                _logEngine.LogInfo($"GiftApiController: /api/GiftApi/Get/{id}", "Starting Method");
                var getData = _giftDataAccess.Get(id);
                var response = new GiftDTO() { GiftId = getData.GiftId, GiftName = getData.GiftName, Priority = getData.Priority, WebUrl = getData.WebUrl, KidId = getData.KidId };
                _logEngine.LogInfo($"GiftApiController: /api/GiftApi/Get/{id}", "Returning Method");
                return Ok(response);
            }
            catch (Exception e) when (e.Message == "Error getting Family record.")
            {
                _logEngine.LogInfo($"GiftApiController: /api/GiftApi/Get/{id}", "Returning NOTFOUND");
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logEngine.LogError("GiftApiController", $"/api/GiftApi/Get/{id}", e.Message);
                return StatusCode(500, "Unknow Failure: Logged");
            }
        }

        // POST: api/GiftApi - Create
        [HttpPost]
        public IActionResult Post([FromBody] GiftDTO gift)
        {
            _logEngine.LogInfo($"GiftApiController: /api/GiftApi/Post/{gift}", "Starting Method");
            var getData = _giftDataAccess.Insert(new Gift { GiftName = gift.GiftName, Priority = gift.Priority, WebUrl = gift.WebUrl, KidId = gift.KidId });
            var response = new GiftDTO { GiftId = getData.GiftId, GiftName = getData.GiftName, Priority = getData.Priority, WebUrl = getData.WebUrl, KidId = getData.KidId };
            _logEngine.LogInfo($"GiftApiController: /api/GiftApi/Post/{gift}", "Returning Method");
            return Created($"/api/GiftAPI/{response.GiftId}", response);
        }

        // PUT: api/GiftApi/5 - Update
        [HttpPut]
        public IActionResult Put([FromBody] GiftDTO gift)
        {
            _logEngine.LogInfo($"GiftApiController: /api/FamilyApi/Put/{gift}", "Starting Method");
            var getDataUpdate = _giftDataAccess.Update(new Gift { GiftId = gift.GiftId, GiftName = gift.GiftName, Priority = gift.Priority, WebUrl = gift.WebUrl, KidId = gift.KidId });
            if (getDataUpdate)
            {
                _logEngine.LogInfo($"GiftApiController: /api/GiftApi/Put/{gift}", "Returning Method");
                return Accepted($"/api/GiftApi/{gift.GiftId}");
            }
            _logEngine.LogInfo($"GiftApiController: /api/GiftApi/Put/{gift}", "Returning NOTFOUND");
            return NotFound();
        }

        // DELETE: api/GiftApi/5 - Do we really want to delete?
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logEngine.LogInfo($"GiftApiController: /api/GiftApi/Delete/{id}", "Starting Method"); 
                _giftDataAccess.Delete(id);
                _logEngine.LogInfo($"GiftApiController: /api/GiftApi/Delete/{id}", "Returning Method");
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logEngine.LogError("GiftApiController", $"/api/GiftApi/Delete/{id}", e.Message);
                _logEngine.LogInfo($"GiftApiController: /api/GiftApi/Delete/{id}", "Returning NOTFOUND");
                return NotFound();
            }
        }
    }
}
