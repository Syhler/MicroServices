using System.ComponentModel.DataAnnotations;

namespace AuthServer.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [EmailAddress]
        [Compare("Email")]
        public string ConfirmEmail { get; set; }
        
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        
        public bool NewsLetter { get; set; }
    }
}