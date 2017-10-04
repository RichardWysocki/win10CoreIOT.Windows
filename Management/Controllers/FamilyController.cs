using System.Web.Mvc;
using Management.Library;
using ServiceContracts;

namespace Management.Controllers
{
    public class FamilyController : Controller
    {
        private readonly IServiceLayer _serviceLayer;

        public FamilyController(IServiceLayer serviceLayer)
        {
            _serviceLayer = serviceLayer;
        }
        // GET: Family
        public ActionResult Index()
        {
            var response = _serviceLayer.GetData<ServiceContracts.Family>("FamilyApi");
            return View(response);
        }

        public ActionResult Create()
        {
            return View();
        }
        // GET: Family/Create
        [HttpPost]
        public ActionResult Create(ServiceContracts.Family newFamily)
        {
            if (ModelState.IsValid)
            {
                _serviceLayer.SendData("FamilyApi", new Family() { FamilyName = newFamily.FamilyName, FamilyEmail = newFamily.FamilyEmail });
                return RedirectToAction("Index");
            }
            return View(newFamily);
        }

        // POST: Family/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        //_serviceLayer.SendData("FamilyApi", new Family() { FamilyName = "SendData", Message = "MyFirstMessage" });
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Family/Edit/5
        public ActionResult Edit(int id)
        {
            var response = _serviceLayer.GetItem<ServiceContracts.Family>("FamilyApi", id);
            return View(response);
        }

        // POST: Family/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ServiceContracts.Family updatFamily)
        {
            try
            {
                // TODO: Add update logic here
                _serviceLayer.Update("FamilyApi", updatFamily);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Family/Delete/5
        public ActionResult Delete(int id)
        {
            _serviceLayer.SendDelete<Family>("FamilyApi", id);
            return RedirectToAction("Index");
        }

    }
}
