using System.Web.Mvc;

using Services.Library;
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
            _serviceLayer.SendData("LogInfo", new LogInfo {Method = "SendData", Message = "MyFirstMessage"});
            ViewBag.Title = "Home Page";

            var response = _serviceLayer.GetData<LogInfo>("LogInfo");

            return View();
        }
    };
}
