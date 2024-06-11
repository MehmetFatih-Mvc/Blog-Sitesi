using Microsoft.AspNetCore.Identity;

namespace neproje.Data
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; } 
    }
}