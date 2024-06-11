using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using neproje.Models;
using neproje.Veri;

namespace neproje.Controllers;

public class HomeController : Controller
{
 
     private DataContext _datacontext;
    public HomeController(DataContext dataContext){
        _datacontext =dataContext;
    }

  public IActionResult Index()
    {
        return RedirectToAction("Privacy");
    }
    public async Task<IActionResult> Privacy()
    {
        return View(
            new AnaViewModel(){
                Abouts = await  _datacontext.Aboats.ToListAsync(),
                Factss = await _datacontext.Facts.ToListAsync(),
                Progres = await _datacontext.Progres.ToListAsync(),
                Galeri =await _datacontext.Galeris.ToListAsync()
            }
        );
    }
       public IActionResult CreateContent(){
         return View();
    }


    [HttpPost]
     public async Task<IActionResult> CreateContent(Content model){

        if(ModelState.IsValid){
          _datacontext.Contents.Add(model);
          await _datacontext.SaveChangesAsync();
          return RedirectToAction("privacy");

        }
         return View();
    }

      public async Task<IActionResult> Mesaj()
      {

      return View(new AnaViewModel(){
        Contents = await _datacontext.Contents.ToListAsync()
      });
      }




    }

  

