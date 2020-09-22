using Microsoft.AspNetCore.Identity;

namespace Auth.Infrastructure.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool NewsLetter { get; set; }
    }
}