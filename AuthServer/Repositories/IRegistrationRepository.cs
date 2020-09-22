using System.Threading.Tasks;
using Auth.Infrastructure.Data.Identity;
using AuthServer.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthServer.Repositories
{
    public interface IRegistrationRepository
    {
        public Task<bool> RegisterUser(RegisterViewModel model);
    }
}