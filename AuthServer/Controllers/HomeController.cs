using System.Collections.Generic;
using System.Linq;
using Auth.Infrastructure.Data.Identity;
using AuthServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AuthServer.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }


        // GET
        public List<ApplicationUser> Index()
        {
            //redirect to main page - get it from appsettings
            return _userManager.Users.ToList();
        }

        public IActionResult Error()
        {
            var model = new ErrorModel
            {
                RedirectUrl = _configuration.GetSection("AppSettings")["RedirectUrl-OnError"]
            };
            
            return View(model);
        }
    }
}