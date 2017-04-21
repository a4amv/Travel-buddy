using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TravelBuddyDatabase.Enums;

namespace TravelBuddy.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Id { get; set; }
        public bool HasPassword { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }

        public string PhoneNumber { get; set; }

        public bool TwoFactor { get; set; }

        public bool BrowserRemembered { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public GenderType Gender { get; set; }

        public string Skype { get; set; }

        public string AboutMe { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email_profil { get; set; }

        public string MyProperty { get; set; }

        public double Ratings { get; set; }

    }
}
