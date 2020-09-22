using System.Threading.Tasks;
using Auth.Infrastructure.Data.Identity;
using AuthServer.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthServer.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        
        
        public RegistrationRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> RegisterUser(RegisterViewModel model)
        {
            
            var applicationModel = new ApplicationUser
            {
                FirstName = model.FirstName,
                UserName = model.Email,
                Email = model.Email,
                LastName = model.LastName,
                NewsLetter = model.NewsLetter
            };

            var result = await _userManager.CreateAsync(applicationModel, model.Password);
            
            //todo log user result 

            var newlyCreatedUser = await _userManager.FindByEmailAsync(applicationModel.Email);

            var roleResult = await _userManager.AddToRoleAsync(newlyCreatedUser, Roles.Regular.ToString());

            // todo log role result

            return result.Succeeded && roleResult.Succeeded;
        }
    }
}