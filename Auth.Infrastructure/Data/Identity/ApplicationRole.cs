using Microsoft.AspNetCore.Identity;

namespace Auth.Infrastructure.Data.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
            
        }
        public ApplicationRole(string roleName) : base(roleName)
        {
        }
    }
}