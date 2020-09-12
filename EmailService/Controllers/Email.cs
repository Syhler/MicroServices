using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.Controllers
{
    public class Email : Controller
    {
        // GET
        [Authorize]
        [HttpPost]
        public string Send(string email, string message)
        {
            return $"I have now send an email to {email} with the message {message}";
        }
    }
}