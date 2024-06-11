using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using neproje.Models;
using neproje.Veri;

namespace neproje.Controllers;

public class AccountController : Controller
{
 
 
    
     
               private DataContext _datacontext;

         public AccountController(DataContext dataContext
    ){
;
            _datacontext =dataContext;
    }
    public IActionResult Login()
    {
        return View();
    }
      [HttpPost]
              
        public IActionResult login(LoginViewModel model)
        {
            if(model.Email == model.Email && model.Password == model.Password){
                return RedirectToAction("AboutList","Admin");
            }

            return View(model);
        }



        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
           public async Task<IActionResult> Create(User model)
        {
            if(ModelState.IsValid){

                _datacontext.users.Add(model);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction("login");

            }
            return View(model);
        }  


        }

  

