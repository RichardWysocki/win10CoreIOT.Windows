using System;
using System.Linq;
using Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceContracts;
using ServiceContracts.Contracts;

namespace Management.Controllers
{
    public class GiftController : Controller
    {
        private readonly IServiceLayers _serviceLayer;

        public GiftController(IServiceLayers serviceLayer)
        {
            _serviceLayer = serviceLayer;
        }
        // GET: Gifts
        public ActionResult Index()
        {
            var giftResponse = _serviceLayer.GetData<GiftDTO>("GiftApi");
            var kidResponse = _serviceLayer.GetData<KidDTO>("KidApi");

            var giftviewModel = giftResponse.Select(x => new GiftViewModel()
                {
                    GiftId = x.GiftId,

                    GiftName = x.GiftName,
                    Priority = x.Priority,
                    WebUrl = x.WebUrl,
                    KidId = x.KidId,
                    KidName = kidResponse.Find(c => c.KidId == x.KidId).Name
                })
                .ToList();

            return View(giftviewModel);
        }

        // GET: Gifts/Create
        public ActionResult Create()
        {
            var response = _serviceLayer.GetData<KidDTO>("KidApi");
            ViewBag.list = new SelectList(response, "KidId", "Name", "----select----");

            return View();
        }

        // POST: Gifts/Create
        [HttpPost]
        public ActionResult Create(GiftDTO newGift)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _serviceLayer.SendData("GiftApi",
                        new GiftDTO() { GiftName = newGift.GiftName, Priority = newGift.Priority, WebUrl = newGift.WebUrl, KidId = newGift.KidId});
                    return RedirectToAction("Index");
                }
                return View(newGift);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index");
            }
        }

        // GET: Gifts/Edit/5
        public ActionResult Edit(int id)
        {
            var kidResponse = _serviceLayer.GetData<GiftDTO>("KidApi");


            var response = _serviceLayer.GetItem<GiftDTO>("GiftApi", id);

            ViewBag.list = new SelectList(kidResponse, "KidId", "Name", response.KidId);
            return View(response);
        }

        // POST: Gifts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KidDTO updateGift)
        {
            try
            {
                // TODO: Add update logic here
                _serviceLayer.Update("GiftApi", updateGift);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gifts/Delete/5
        public ActionResult Delete(int id)
        {
            _serviceLayer.SendDelete<GiftDTO>("GiftApi", id);
            return RedirectToAction("Index");
        }

    }
}
