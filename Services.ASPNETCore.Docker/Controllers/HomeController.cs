using System;
using Microsoft.AspNetCore.Mvc;

namespace Services.ASPNETCore.Docker.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            var serverName = Environment.MachineName;
            return Content(
                $"Server Address {serverName}"
            );
        }
    }
}