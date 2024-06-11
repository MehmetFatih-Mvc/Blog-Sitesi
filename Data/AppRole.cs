using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace neproje.Data
{
    public class AppRole : IdentityRole
    {
       
        public string FullName { get; set; } =string.Empty;
    }
}