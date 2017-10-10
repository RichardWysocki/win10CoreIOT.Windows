using System.Configuration;
using System.Web.Mvc;
using Management.Library;
using ServiceContracts.NewFolder;
using win10Core.Business.Model;

namespace Management.Controllers
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


            var x = new ServiceContracts.NewFolder.ServiceLayers(
                new ServiceSettings(ConfigurationManager.AppSettings["ServiceURL"]));
            x.SendData("LogInfo", new LogInfo { Method = "SendData", Message = "MyFirstMessage" });



            _serviceLayer.SendData("LogInfo", new LogInfo { Method = "SendData", Message = "MyFirstMessage" });
            ViewBag.Title = "Home Page";

            var response = _serviceLayer.GetData<LogInfo>("LogInfo");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}