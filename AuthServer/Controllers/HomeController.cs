using AuthServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AuthServer.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // GET
        public IActionResult Index()
        {
            //redirect to main page - get it from appsettings
            return View();
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