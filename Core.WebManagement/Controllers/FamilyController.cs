
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.Contracts;

namespace Management.Controllers
{
    public class FamilyController : Controller
    {
        private readonly IServiceLayers _serviceLayer;

        public FamilyController(IServiceLayers serviceLayer)
        {
            _serviceLayer = serviceLayer;
        }
        // GET: Family
        public IActionResult Index()
        {
            var response = _serviceLayer.GetData<FamilyDTO>("FamilyApi");
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }
        // GET: Family/Create
        [HttpPost]
        public IActionResult Create(FamilyDTO newFamily)
        {
            if (ModelState.IsValid)
            {
                _serviceLayer.SendData("FamilyApi", new FamilyDTO() { FamilyName = newFamily.FamilyName, FamilyEmail = newFamily.FamilyEmail });
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
        public IActionResult Edit(int id)
        {
            var response = _serviceLayer.GetItem<FamilyDTO>("FamilyApi", id);
            return View(response);
        }

        // POST: Family/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, FamilyDTO updatFamily)
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
            _serviceLayer.SendDelete<FamilyDTO>("FamilyApi", id);
            return RedirectToAction("Index");
        }

    }
}
