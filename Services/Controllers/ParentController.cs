using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ServiceContracts;
using Services.Library;
using Services.Models;

namespace Services.Controllers
{
    public class ParentController : Controller
    {
        private readonly IServiceLayer _serviceLayer;

        public ParentController(IServiceLayer serviceLayer)
        {
            _serviceLayer = serviceLayer;
        }
        // GET: Parent
        public ActionResult Index()
        {
            var familyResponse = _serviceLayer.GetData<Family>("FamilyApi");
            var parentResponse = _serviceLayer.GetData<Parent>("ParentApi");

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

        //// GET: Parent/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Parent/Create
        public ActionResult Create()
        {
            var response = _serviceLayer.GetData<Family>("FamilyApi");
            ViewBag.list = new SelectList(response, "FamilyId", "FamilyName", "----select----");

            return View();
        }

        // POST: Parent/Create
        [HttpPost]
        public ActionResult Create(Parent newParent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceLayer.SendData("ParentApi",
                        new Parent() { Name = newParent.Name, Email = newParent.Email, FamilyId = newParent.FamilyId });
                    return RedirectToAction("Index");
                }
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
            var familyResponse = _serviceLayer.GetData<Family>("FamilyApi");
            

            var response = _serviceLayer.GetItem<Parent>("ParentApi", id);
            //ViewBag.list = new SelectList(response, "FamilyId", "FamilyName", "----select----");
            ViewBag.list = new SelectList(familyResponse, "FamilyId", "FamilyName", response.FamilyId);
            return View(response);
        }

        // POST: Parent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Parent updateParent)
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
            _serviceLayer.SendDelete<Parent>("ParentApi", id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            throw new NotImplementedException();
        }
    }
}
