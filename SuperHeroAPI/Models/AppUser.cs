using Microsoft.AspNetCore.Identity;

namespace SuperHeroAPI.Models
{
    public class AppUser : IdentityUser
    {
        public string Country { get; set; }

        public int Age { get; set; }
    }
}
