using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBuddyDatabase;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using TravelBuddyDatabase.Enums;

using Microsoft.AspNetCore.Authorization;

using Microsoft.Extensions.Logging;
using TravelBuddyDatabase.Entities;
using TravelBuddy.Models;
using TravelBuddy.Models.ManageViewModels;
using TravelBuddyServices.Communication;
using TravelBuddy.Models.FinderViewModel;

namespace TravelBuddy.Controllers
{
   
    public class FinderController : Controller
    {
        protected ApplicationDbContextFactory DbFactory { get; set; }
        public FinderController(ApplicationDbContextFactory dbFactory)
        {
            DbFactory = dbFactory;
        }
        /*  public IActionResult Index()
          {
              return View();
          }*/



        //vrati view vsech uzivatelu
        public ActionResult Index(string searchString)
        {
            //Restore data from request
            /*if (TempData.ContainsKey(MessageKey))
            {
                ViewData[MessageKey] = TempData[MessageKey];
            }*/

            if (!String.IsNullOrEmpty(searchString))
            {
                char[] charsToTrim = { ' ' };
                searchString = searchString.Trim(charsToTrim);
            }
            using (var db = DbFactory.Create())
            {
                var data = db.Users.Select(a => new FinderViewModel()
                {
                    Name = a.Name,
                    city = a.City,
                });


                if (!String.IsNullOrEmpty(searchString))
                {
                    data = data.Where(a => a.city.Contains(searchString));
                }
                return View(data.ToList());


            }
        }

        public ActionResult Detail(string userID)
        {
            return null;
        }
    }
}
