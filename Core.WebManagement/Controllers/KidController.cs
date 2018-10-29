using System;
using System.Linq;
using Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceContracts;
using ServiceContracts.Contracts;

namespace Management.Controllers
{
    public class KidController : Controller
    {
        private readonly IServiceLayers _serviceLayer;

        public KidController(IServiceLayers serviceLayer)
        {
            _serviceLayer = serviceLayer;
        }
        // GET: Parent
        public ActionResult Index()
        {
            var kidResponse = _serviceLayer.GetData<KidDTO>("KidApi");
            var familyResponse = _serviceLayer.GetData<FamilyDTO>("FamilyApi");

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
            var response = _serviceLayer.GetData<KidDTO>("KidApi");
            ViewBag.list = new SelectList(response, "KidId", "Name", "----select----");

            return View();
        }

        // POST: Parent/Create
        [HttpPost]
        public ActionResult Create(KidDTO newKid)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceLayer.SendData("KidApi",
                        new KidDTO() { Name = newKid.Name, Email = newKid.Email, FamilyId = newKid.FamilyId });
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
            var familyResponse = _serviceLayer.GetData<FamilyDTO>("FamilyApi");
            

            var response = _serviceLayer.GetItem<KidDTO>("KidApi", id);
            //ViewBag.list = new SelectList(response, "FamilyId", "FamilyName", "----select----");
            ViewBag.list = new SelectList(familyResponse, "FamilyId", "FamilyName", response.FamilyId);
            return View(response);
        }

        // POST: Parent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KidDTO updateKid)
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
            _serviceLayer.SendDelete<KidDTO>("KidApi", id);
            return RedirectToAction("Index");
        }

    }
}
