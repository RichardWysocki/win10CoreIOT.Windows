using System;
using System.Linq;
using System.Web.Mvc;
using ServiceContracts;
using Services.Library;
using Services.Models;

namespace Services.Controllers
{
    public class KidController : Controller
    {
        private readonly IServiceLayer _serviceLayer;

        public KidController(IServiceLayer serviceLayer)
        {
            _serviceLayer = serviceLayer;
        }
        // GET: Parent
        public ActionResult Index()
        {
            var kidResponse = _serviceLayer.GetData<Kid>("KidApi");
            var familyResponse = _serviceLayer.GetData<Family>("FamilyApi");

            var parentviewModel = kidResponse.Select(x => new KidViewModel()
                {
                    KidId = x.KidId,
                    Name = x.Name,
                    Email = x.Email,
                    FamilyId = x.FamilyId,
                    FamilyName = familyResponse.Find(c => c.FamilyId == x.FamilyId).FamilyName
                })
                .ToList();

            return View(parentviewModel);
        }

        // GET: Parent/Create
        public ActionResult Create()
        {
            var response = _serviceLayer.GetData<Kid>("KidApi");
            ViewBag.list = new SelectList(response, "KidId", "Name", "----select----");

            return View();
        }

        // POST: Parent/Create
        [HttpPost]
        public ActionResult Create(Kid newKid)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceLayer.SendData("KidApi",
                        new Kid() { Name = newKid.Name, Email = newKid.Email, FamilyId = newKid.FamilyId });
                    return RedirectToAction("Index");
                }
                return View(newKid);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index");
            }
        }

        // GET: Kid/Edit/5
        public ActionResult Edit(int id)
        {
            var familyResponse = _serviceLayer.GetData<Family>("FamilyApi");
            

            var response = _serviceLayer.GetItem<Kid>("KidApi", id);
            //ViewBag.list = new SelectList(response, "FamilyId", "FamilyName", "----select----");
            ViewBag.list = new SelectList(familyResponse, "FamilyId", "FamilyName", response.FamilyId);
            return View(response);
        }

        // POST: Parent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Kid updateKid)
        {
            try
            {
                // TODO: Add update logic here
                _serviceLayer.Update("KidApi", updateKid);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parent/Delete/5
        public ActionResult Delete(int id)
        {
            _serviceLayer.SendDelete<Kid>("KidApi", id);
            return RedirectToAction("Index");
        }

    }
}
