using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Batch;
using System.Web.Mvc;

namespace Services.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //var response = GetData();




            return View();
        }

        private static string GetData()
        {
            var getData = new HttpClient();
            var response = getData.GetAsync(new Uri("http://localhost:34909/api/Client")).Result;
            var data = response.Content.ReadAsStringAsync().Result;

            return data;
        }

    };
}
