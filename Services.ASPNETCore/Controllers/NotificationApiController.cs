using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.ASPNETCore.Model;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Engine;
using win10Core.Business.Engine.Interface;
using win10Core.Business.Model;
using GiftDTO = ServiceContracts.Contracts.GiftDTO;

namespace Services.ASPNETCore.Controllers
{
    [Route("api/[controller]")]

    public class NotificationApiController : Controller
    {
        private readonly IGiftDataAccess _giftDataAccess;
        private readonly IEmailEngine _emailEngine;
        private readonly IFamilyDataAccess _familyDataAccess;
        private readonly IKidDataAccess _kidDataAccess;
        //private readonly ILogErrorDataAccess _logErrorDataAccess;
        private readonly ILogEngine _logEngine;
        //private readonly WebSettings _webSetting;
        private IParentDataAccess _parentDataAccess;

        public NotificationApiController(
            //IOptions<WebSettings> webSettings,
            IEmailEngine emailEngine, IGiftDataAccess giftDataAccess,  IFamilyDataAccess familyDataAccess, IParentDataAccess parentDataAccess,
            IKidDataAccess kidDataAccess, ILogErrorDataAccess logErrorDataAccess, ILogEngine logEngine)
        {
            _giftDataAccess = giftDataAccess;
            _emailEngine = emailEngine;
            _familyDataAccess = familyDataAccess;
            _parentDataAccess = parentDataAccess;
            _kidDataAccess = kidDataAccess;
           // _logErrorDataAccess = logErrorDataAccess;
            _logEngine = logEngine;
            //_webSetting = webSettings.Value;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetNewRegisteredGifts/{id}", Name = "GetNewRegisteredGifts")]
        public IActionResult GetNewRegisteredGifts(string id)
        {
            var getData = _giftDataAccess.GetEmailList(id == "true");
            var response = getData
                .Select(c => new GiftDTO()
                {
                    GiftId = c.GiftId,
                    GiftName = c.GiftName,
                    Priority = c.Priority,
                    WebUrl = c.WebUrl,
                    KidId = c.KidId,
                    CreateDate = c.CreateDate,
                    EmailSent = c.EmailSent
                }).ToList();
            return Ok(response);
        }

        [HttpPost("NotifyParentsofNewGift", Name = "NotifyParentsofNewGift")]
        public IActionResult NotifyParentsofNewGift([FromBody] GiftDTO gift)
        {
            Family family;
            Kid kid;
            List<Parent> parent;
            if ( null == gift || gift.GiftId == 0)
            {
                _logEngine.LogInfo($"NotificationApiController: NotifyParentsofNewGift", "Returning NOTFOUND");
                return NotFound();
            }

            try
            {
                kid = _kidDataAccess.Get(gift.KidId);
                family = _familyDataAccess.Get(kid.FamilyId);
                parent = _parentDataAccess.GetbyFamily(kid.FamilyId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logEngine.LogError("NotificationApiController", $"/api/NotificationApiController/NotifyParentsofNewGift", gift + ": " + e.Message);
                return StatusCode(500, "Unknow Failure: Logged");
            }


            _emailEngine.Send(family.FamilyName, family.FamilyEmail, "Gift Registered for: " + kid.Name, "This Gift has been Setup: "+ gift.GiftName, "RichardWysocki@gmail.com");
            foreach (var p in parent)
            {
                _emailEngine.Send(p.Name, p.Email, "Gift Registered for: " + kid.Name, "This Gift has been Setup: " + gift.GiftName, "RichardWysocki@gmail.com");
            }

            var getData = _giftDataAccess.Update(new Gift
            {
                GiftId = gift.GiftId,
                GiftName = gift.GiftName,
                Priority = gift.Priority,
                WebUrl = gift.WebUrl,
                KidId = gift.KidId,
                CreateDate = DateTime.Now,
                EmailSent = true
            });
            return Ok(getData);
        }

        //[HttpPost]
        //[ActionName("SomethingElseHere")]
        //public bool SomethingElseHere(GiftDTO gift)
        //{
        //    var kid = _kidDataAccess.Get(gift.KidId);
        //    var family = _familyDataAccess.Get(kid.FamilyId);

        //    var sendemail = new EmailEngine(
        //        new EmailConfiguration
        //        {
        //            SmtpServer = _webSetting.SmtpServer,
        //            SmtpPort = _webSetting.SmtpPort,
        //            SmtpServerUserName = _webSetting.AuthUserName,
        //            SmtpServerPassword = _webSetting.AuthPassword
        //        }
        //        , _logErrorDataAccess);
        //    //, new LogErrorDataAccess(new DBContext()));

        //    //sendemail.Send(family.FamilyName, family.FamilyEmail, "Sample Message", "Hello Text", "RichardWysocki@gmail.com");

        //    var getData = _giftDataAccess.Update(new Gift
        //    {
        //        GiftId = gift.GiftId,
        //        GiftName = gift.GiftName,
        //        Priority = gift.Priority,
        //        WebUrl = gift.WebUrl,
        //        KidId = gift.KidId,
        //        CreateDate = DateTime.Now,
        //        EmailSent = true
        //    });
        //    return getData;
        //}

        // GET: api/NotificationApi
        //public IEnumerable<string> Get()
        //{
        //    return new string[] {"value1", "value2"};
        //}

        // GET: api/NotificationApi/5
        [HttpGet("hi/{id}", Name ="Hi")]
        public IActionResult Get(int id)
        {
            return Ok("value");
        }

        //// POST: api/NotificationApi
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/NotificationApi/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/NotificationApi/5
        //public void Delete(int id)
        //{
        //}
    }
}