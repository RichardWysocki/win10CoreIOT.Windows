using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceContracts;
using Services.Library;
using Services.Models;

namespace Services.Controllers
{
    public class GiftController : Controller
    {
        private readonly IServiceLayer _serviceLayer;

        public GiftController(IServiceLayer serviceLayer)
        {
            _serviceLayer = serviceLayer;
        }
        // GET: Gifts
        public ActionResult Index()
        {
            var giftResponse = _serviceLayer.GetData<Gift>("GiftApi");
            var kidResponse = _serviceLayer.GetData<Kid>("KidApi");

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

        //// GET: Gifts/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Gifts/Create
        public ActionResult Create()
        {
            var response = _serviceLayer.GetData<Gift>("GiftApi");
            ViewBag.list = new SelectList(response, "KidId", "KidName", "----select----");

            return View();
        }

        // POST: Gifts/Create
        [HttpPost]
        public ActionResult Create(Gift newGift)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceLayer.SendData("GiftApi",
                        new Gift() { GiftName = newGift.GiftName, Priority = newGift.Priority, WebUrl = newGift.WebUrl, KidId = newGift.KidId});
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
            var kidResponse = _serviceLayer.GetData<Gift>("KidApi");


            var response = _serviceLayer.GetItem<Gift>("GiftApi", id);

            ViewBag.list = new SelectList(kidResponse, "KidId", "Name", response.KidId);
            return View(response);
        }

        // POST: Gifts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Kid updateGift)
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
            _serviceLayer.SendDelete<Gift>("GiftApi", id);
            return RedirectToAction("Index");
        }

    }
}
