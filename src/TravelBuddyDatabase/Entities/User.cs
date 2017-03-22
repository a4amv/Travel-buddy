using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TravelBuddyDatabase.Entities
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string Country { get; set; }
    }
}
