using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Management.Library;
using ServiceContracts;
using ServiceContracts.Contracts;
using win10Core.Business;
using win10Core.Business.Model;

namespace Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceLayer _serviceLayer;
        private readonly IServiceLayers _serviceLayers;

        public HomeController(IServiceLayer serviceLayer, IServiceLayers serviceLayers)
        {
            _serviceLayer = serviceLayer;
            _serviceLayers = serviceLayers;
        }
        public ActionResult Index()
        {


            //var x = new ServiceLayers(
            //    new ServiceSettings(ConfigHelper.GetSetting("ServiceURL")));
            _serviceLayers.SendData("LogInfo", new LogInformation { Method = "HomeController: Index", Message = "ServiceLayers Method" });

           
   
            
            _serviceLayer.SendData("LogInfo", new LogInformation { Method = "HomeController: Index", Message = "Service Layer...  Method" });
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