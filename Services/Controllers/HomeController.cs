using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using Contracts;
using win10Core.Business.DataAccess;

namespace Services.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var logInfoDataAccess = new LogInfoDataAccess(new DBContext());
            logInfoDataAccess.Insert(new win10Core.Business.Model.LogInfo { Method = "", Message = "Starting... Index" });
            ViewBag.Title = "Home Page";

            var response = GetData();




            return View();
        }

        private static List<LogInfo> GetData()
        {
            var getData = new HttpClient();
            var response = getData.GetAsync(new Uri("http://localhost:34909/api/LogInfo")).Result;
            var data = response.Content.ReadAsAsync<List<LogInfo>>().Result;

            return data;
        }

    };
}
