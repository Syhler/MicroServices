using System;
using System.Threading.Tasks;
using Auth.Infrastructure.Data.Identity;
using AuthServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        // GET
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel{ReturnUrl = returnUrl});
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string button)
        {
            //check return url safety thingy
            
            
            if (button == "submit")
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Username, model.Password, 
                        model.IsPersistence, false);

                if (result.Succeeded)
                {
                    return Redirect(model.ReturnUrl);
                }
            }

            return View();
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