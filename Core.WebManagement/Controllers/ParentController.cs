using System;
using System.Linq;
using Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceContracts;
using ServiceContracts.Contracts;

namespace Management.Controllers
{
    public class ParentController : Controller
    {
        private readonly IServiceLayers _serviceLayer;

        public ParentController(IServiceLayers serviceLayer)
        {
            _serviceLayer = serviceLayer;
        }
        // GET: Parent
        public ActionResult Index()
        {
            var familyResponse = _serviceLayer.GetData<FamilyDTO>("FamilyApi");
            var parentResponse = _serviceLayer.GetData<ParentDTO>("ParentApi");

            var parentviewModel = parentResponse.Select(x => new ParentViewModelIndex
                {
                    ParentId = x.ParentId,
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
            var response = _serviceLayer.GetData<FamilyDTO>("FamilyApi");
            ViewBag.list = new SelectList(response, "FamilyId", "FamilyName", "----select----");

            return View();
        }

        // POST: Parent/Create
        [HttpPost]
        public ActionResult Create(ParentDTO newParent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceLayer.SendData("ParentApi",
                        new ParentDTO() { Name = newParent.Name, Email = newParent.Email, FamilyId = newParent.FamilyId });
                    return RedirectToAction("Index");
                }
                var response = _serviceLayer.GetData<FamilyDTO>("FamilyApi");
                ViewBag.list = new SelectList(response, "FamilyId", "FamilyName", "----select----");
                return View(newParent);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index");
            }
        }

        // GET: Parent/Edit/5
        public ActionResult Edit(int id)
        {
            var familyResponse = _serviceLayer.GetData<FamilyDTO>("FamilyApi");
            

            var response = _serviceLayer.GetItem<ParentDTO>("ParentApi", id);
            //ViewBag.list = new SelectList(response, "FamilyId", "FamilyName", "----select----");
            ViewBag.list = new SelectList(familyResponse, "FamilyId", "FamilyName", response.FamilyId);
            return View(response);
        }

        // POST: Parent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ParentDTO updateParent)
        {
            try
            {
                // TODO: Add update logic here
                _serviceLayer.Update("ParentApi", updateParent);
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
            _serviceLayer.SendDelete<ParentDTO>("ParentApi", id);
            return RedirectToAction("Index");
        }

    }
}
