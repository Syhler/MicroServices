namespace AuthServer.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsPersistence { get; set; }
        
        public string ReturnUrl { get; set; }
    }
}