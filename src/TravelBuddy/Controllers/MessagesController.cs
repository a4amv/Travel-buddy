using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using TravelBuddyDatabase;
using TravelBuddyDatabase.Entities;
using TravelBuddy.Models.Messages;

namespace TravelBuddy.Controllers
{
    public class MessagesController : Controller
    {
        protected ApplicationDbContextFactory DbFactory { get; set; }

        public MessagesController(ApplicationDbContextFactory dbFactory)
        {
            DbFactory = dbFactory;
        }
        // GET: Messages
        public ActionResult Index()
        {
            using (var db = DbFactory.Create())
            {
                //var data = db.Messages.Select(a => a.SentFrom != User.Identity.Name ? a.SentFrom : a.SentTo)
                //    .Where(b => b == User.Identity.Name )
                //              .Distinct()
                //              .ToList();

                var data = db.Messages.Select(a => new { SentFrom = a.SentFrom, SentTo = a.SentTo })
                    .Where(b => b.SentFrom == User.Identity.Name || b.SentTo == User.Identity.Name)
                    .Select(a => a.SentFrom != User.Identity.Name ? a.SentFrom : a.SentTo)
                              .Distinct()
                              .ToList();
                return View(data);
            }
        }

        // GET: Messages/Details/5
        public ActionResult Details(int id)
        {
            using (var db = DbFactory.Create())
            {
                var data = db.Messages.Select(a => new MessagesViewModel()
                {
                    Id = a.Id,
                    SentFrom = a.SentFrom,
                    SentTo = a.SentTo,
                    IsRead = a.IsRead,
                    ThisMessage = a.ThisMessage,
                    MessageTime = a.MessageTime
                }).Where( a => a.SentTo == User.Identity.Name) .ToList();
                return View(data);
            }
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessagesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                using (var db = DbFactory.Create())
                {
                    db.Messages.Add(new Messages()
                    {
                        SentFrom = model.SentFrom,
                        SentTo = model.SentTo,
                        IsRead = model.IsRead,
                        ThisMessage = model.ThisMessage,
                        MessageTime = model.MessageTime
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

        // GET: Messages/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = DbFactory.Create())
            {
                var data = db.Messages.Select(a => new MessagesViewModel()
                {
                    Id = a.Id,
                    SentFrom = a.SentFrom,
                    SentTo = a.SentTo,
                    IsRead = a.IsRead,
                    ThisMessage = a.ThisMessage,
                    MessageTime = a.MessageTime
                }).First(a => a.Id == id);
                return View(data);
            }
        }

        // POST: Messages/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MessagesViewModel model)
        {
            try
            {
                using (var db = DbFactory.Create())
                {
                    var entity = db.Messages.First(a => a.Id == model.Id);
                    entity.SentFrom = model.SentFrom;
                    entity.SentTo = model.SentTo;
                    entity.IsRead = model.IsRead;
                    entity.ThisMessage = model.ThisMessage;
                    entity.MessageTime = model.MessageTime;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Messages/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}