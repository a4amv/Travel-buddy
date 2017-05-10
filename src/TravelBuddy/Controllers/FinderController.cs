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
        private readonly UserManager<User> _userManager;
        

        protected ApplicationDbContextFactory DbFactory { get; set; }
        public FinderController(ApplicationDbContextFactory dbFactory, UserManager<User> userManager)
        {
            _userManager = userManager;
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
            ViewData["searchedString"] = searchString;
            using (var db = DbFactory.Create())
            {
                var data = db.Users.Select(a => new FinderViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    city = a.City,
                    PathToImage = a.PathToImage,
                });


                if (!String.IsNullOrEmpty(searchString))
                {
                    data = data.Where(a => a.city.Contains(searchString));
                }
                return View(data.ToList());


            }
        }

        public async Task<ActionResult> Detail(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return View("Error");
            }
            var model = new IndexViewModel
            {
                Id = user.Id,
                
                Name = user.Name,
                Surname = user.Surname,
                Country = user.Country,
                Birthday = user.Birthday,
                City = user.City,
                Skype = user.Skype,
                Gender = user.Gender,
                AboutMe = user.AboutMe,
                PathToImage = user.PathToImage
            };
            return View(model);
        }
    }
}
