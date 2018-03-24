using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.ASPNETCore.Docker.Model;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Engine;
using win10Core.Business.Model;
using GiftDTO = ServiceContracts.Contracts.GiftDTO;

namespace Services.ASPNETCore.Docker.Controllers
{
    [Route("api/[controller]")]

    public class NotificationApiController : Controller
    {
        private readonly IGiftDataAccess _giftDataAccess;
        private readonly IEmailEngine _emailEngine;
        private readonly IFamilyDataAccess _familyDataAccess;
        private readonly IKidDataAccess _kidDataAccess;
        private readonly ILogErrorDataAccess _logErrorDataAccess;
        private readonly WebSettings _webSetting;

        public NotificationApiController(IOptions<WebSettings> webSettings, IEmailEngine emailEngine, IGiftDataAccess giftDataAccess,  IFamilyDataAccess familyDataAccess, IKidDataAccess kidDataAccess, ILogErrorDataAccess logErrorDataAccess)
        {
            _giftDataAccess = giftDataAccess;
            _emailEngine = emailEngine;
            _familyDataAccess = familyDataAccess;
            _kidDataAccess = kidDataAccess;
            _logErrorDataAccess = logErrorDataAccess;
            _webSetting = webSettings.Value;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetNewRegisteredGifts")]
        public IEnumerable<GiftDTO> GetNewRegisteredGifts(string id)
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
            return response;
        }

        [HttpPost]
        [ActionName("NotifyParentsofNewGift")]
        public bool NotifyParentsofNewGift(GiftDTO gift)
        {
            win10Core.Business.Model.Family family;
            if ( null == gift || gift.GiftId == 0)
            {
                throw new Exception("Invalid Gift to Update.");
            }
            try
            {
                var kid = _kidDataAccess.Get(gift.KidId);
                family = _familyDataAccess.Get(kid.FamilyId);
            }
            catch (Exception e)
            {
                throw new Exception("Invalid Gift to Update.");
            }

            //var sendemail = new EmailEngine(
            //    new EmailConfiguration
            //    {
            //        SMTPServer = ConfigHelper.GetSetting("SMTPServer"),
            //        SmtpServerUserName = ConfigHelper.GetSetting("AuthUserName"),
            //        SmtpServerPassword = ConfigHelper.GetSetting("AuthPassword")
            //    }
            //    , new LogErrorDataAccess(new DBContext()));

            _emailEngine.Send(family.FamilyName, family.FamilyEmail, "Sample Message", "Hello Text", "RichardWysocki@gmail.com");

            var getData = _giftDataAccess.Update(new win10Core.Business.Model.Gift
            {
                GiftId = gift.GiftId,
                GiftName = gift.GiftName,
                Priority = gift.Priority,
                WebUrl = gift.WebUrl,
                KidId = gift.KidId,
                CreateDate = DateTime.Now,
                EmailSent = true
            });
            return getData;
        }

        [HttpPost]
        [ActionName("SomethingElseHere")]
        public bool SomethingElseHere(GiftDTO gift)
        {
            var kid = _kidDataAccess.Get(gift.KidId);
            var family = _familyDataAccess.Get(kid.FamilyId);

            var sendemail = new EmailEngine(
                new EmailConfiguration
                {
                    SmtpServer = _webSetting.SmtpServer,
                    SmtpPort = _webSetting.SmtpPort,
                    SmtpServerUserName = _webSetting.AuthUserName,
                    SmtpServerPassword = _webSetting.AuthPassword
                }
                , _logErrorDataAccess);
            //, new LogErrorDataAccess(new DBContext()));

            // sendemail.Send(family.FamilyName, family.FamilyEmail, "Sample Message", "Hello Text", "RichardWysocki@gmail.com");

            var getData = _giftDataAccess.Update(new win10Core.Business.Model.Gift
            {
                GiftId = gift.GiftId,
                GiftName = gift.GiftName,
                Priority = gift.Priority,
                WebUrl = gift.WebUrl,
                KidId = gift.KidId,
                CreateDate = DateTime.Now,
                EmailSent = true
            });
            return getData;
        }

        // GET: api/NotificationApi
        public IEnumerable<string> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET: api/NotificationApi/5
        public string Get(int id)
        {
            return "value";
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
        public void Delete(int id)
        {
        }
    }
}