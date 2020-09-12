using System;
using System.Threading.Tasks;
using Auth.Infrastructure.Data.Identity;
using AuthServer.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AuthServer.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        
        public AccountController(SignInManager<ApplicationUser> signInManager, IIdentityServerInteractionService interaction)
        {
            _signInManager = signInManager;
            _interaction = interaction;
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
            if (!ModelState.IsValid) return View(model.ReturnUrl);

            var validReturnUrl = _interaction.IsValidReturnUrl(model.ReturnUrl);

            if (!validReturnUrl) return RedirectToAction("Error","Home"); //return to error page

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
            else
            {
                return Redirect(model.ReturnUrl);
            }

            return RedirectToAction("Error","Home");
        }

        public async Task<IActionResult> Logout(string logOutId)
        {
            await _signInManager.SignOutAsync();

            var logoutRequest = await _interaction.GetLogoutContextAsync(logOutId);

            if (string.IsNullOrWhiteSpace(logoutRequest.PostLogoutRedirectUri))
            {
                return RedirectToAction(""); //Return to error page
            }
            
            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }


        //register from clients
        
        public IActionResult Register()
        {
            return Ok();
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
    }
}