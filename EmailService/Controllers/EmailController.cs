using System.Collections.Generic;
using EmailService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.Controllers
{
    public class EmailController : Controller
    {
        // GET
        [HttpPost]
        [Authorize]
        public ActionResult Send(EmailViewModel model)
        {
            List<string> result = new List<string>();
            result.Add("Message: aalalala");
            result.Add($"Message: {model.Message}");
            result.Add($"Email: {model.Email}");
            
            return Ok(result);

        }
    }
}