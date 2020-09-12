using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            //redirect to main page - get it from appsettings
            return View();
        }
    }
}