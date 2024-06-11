using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using neproje.Data;

namespace neproje.Controllers;
public class UserController : Controller{


       

      
     private UserManager<AppUser> _userManager;
     private RoleManager<AppRole> _roleManager;
     public UserController(UserManager<AppUser> userManager , RoleManager<AppRole> roleManager)
     {
        _userManager = userManager;
        _roleManager = roleManager;
     }
        public IActionResult Index()
        {

      
            return View();
        }
        


       
       // [AllowAnonymous] // bu da her parametre kapalı admin olmayan kullanıcılar hariç  sadece bu açık 
       
    


    }

          


