using System;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Controllers
{
    public class AuthController : Controller
    {
        // GET
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string returnUrl, string button)
        {
            //check return url safety thingy
            
            
            if (button == "submit")
            {
                
            }

            return Redirect(returnUrl);
        }

        
        [HttpGet]
        public IActionResult ForgotUserLogin()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult ForgotUserLogin(string model)
        {
            throw new NotImplementedException();
        }
        
        
        public IActionResult Logout()
        {
            return SignOut();
        }


        //register from clients
        
        public IActionResult Register()
        {
    

            return Ok();
        }
    }
}