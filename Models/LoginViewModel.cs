using System.ComponentModel.DataAnnotations;

namespace neproje.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } =null!;


        public bool RememberMe { get; set; } =true;
    }
}