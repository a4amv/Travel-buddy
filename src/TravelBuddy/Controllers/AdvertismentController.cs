using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBuddy.Models.Advertisment;
using TravelBuddyDatabase;
using TravelBuddyDatabase.Entities;

namespace TravelBuddy.Controllers
{
    public class AdvertismentController : Controller
    {
        protected ApplicationDbContextFactory DbFactory { get; set; }

        public AdvertismentController(ApplicationDbContextFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        // GET: Advertisment
        public ActionResult Index()
        {
            using (var db = DbFactory.Create())
            {
                var data = db.Advertisment.Select(a => new AdvertismentViewModel()
                {
                    Id = a.Id,
                    Since = a.Since,
                    Details = a.Details,
                    Location = a.Location,
                    Until = a.Until
                }).ToList();
                return View(data);
            }
        }

        // GET: Advertisment/Details/5
        public ActionResult Details(int id)
        {
            using (var db = DbFactory.Create())
            {
                var data = db.Advertisment.Select(a => new AdvertismentViewModel()
                {
                    Id = a.Id,
                    Since = a.Since,
                    Details = a.Details,
                    Location = a.Location,
                    Until = a.Until
                }).First(a => a.Id == id);
                return View(data);
            }
        }

        // GET: Advertisment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Advertisment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdvertismentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                using (var db = DbFactory.Create())
                {
                    db.Advertisment.Add(new Advertisment()
                    {
                        Since = model.Since,
                        Details = model.Details,
                        Location = model.Location,
                        Until = model.Until
                    });
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Advertisment/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = DbFactory.Create())
            {
                var data = db.Advertisment.Select(a => new AdvertismentViewModel()
                {
                    Id = a.Id,
                    Since = a.Since,
                    Details = a.Details,
                    Location = a.Location,
                    Until = a.Until
                }).First(a => a.Id == id);
                return View(data);
            }
        }

        // POST: Advertisment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdvertismentViewModel collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Advertisment/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}