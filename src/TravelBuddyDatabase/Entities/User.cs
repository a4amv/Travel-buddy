using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TravelBuddyDatabase.Enums;

namespace TravelBuddyDatabase.Entities
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        
        public DateTime Birthday { get; set; }

        public GenderType Gender { get; set; }

        public string Skype { get; set; }
    }
}
