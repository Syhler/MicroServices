using System.ComponentModel.DataAnnotations;

namespace AuthServer.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
        public bool IsPersistence { get; set; }

        [Required]
        public string ReturnUrl { get; set; }
    }
}