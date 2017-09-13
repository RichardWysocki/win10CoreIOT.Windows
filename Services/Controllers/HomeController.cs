using System.Web.Mvc;

using Services.Library;
using win10Core.Business;
using win10Core.Business.DataAccess;
using win10Core.Business.Engine;
using win10Core.Business.Model;

namespace Services.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceLayer _serviceLayer;

        public HomeController(IServiceLayer serviceLayer)
        {
            _serviceLayer = serviceLayer;
        }

        public ActionResult Index()
        {

            var sendemail = new EmailEngine(
                new EmailConfiguration
                    { SMTPServer = ConfigHelper.GetSetting("SMTPServer"),
                    SmtpServerUserName = ConfigHelper.GetSetting("AuthUserName"),
                    SmtpServerPassword = ConfigHelper.GetSetting("AuthPassword") }
                , new LogErrorDataAccess(new DBContext()));

            sendemail.Send("RichardWysocki@gmailcom", "RichardWysocki@gmail.com", "Sample Message", "Hello Text", "RichardWysocki@gmail.com");


            _serviceLayer.SendData("LogInfo", new LogInfo {Method = "SendData", Message = "MyFirstMessage"});
            ViewBag.Title = "Home Page";

            var response = _serviceLayer.GetData<LogInfo>("LogInfo");

            return View();
        }
    };
}
