using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using neproje.Models;
using neproje.Veri;


namespace neproje.Controllers;

public class AdminController : Controller
{

    private DataContext _datacontext;
  

    public AdminController(DataContext dataContext){
        _datacontext =dataContext;
    }

 public IActionResult Index(){

   return RedirectToAction("Login","Account");
}



public IActionResult AboutCreate(){
    return View();
}

[HttpPost]

 public async Task<IActionResult> AboutCreate(About model, IFormFile imageFile)
    {    
       

          var extension="";
        if(imageFile != null){// eğer bir  resim seçmediysek error mesajı verir


        // girilecek resmin hangi türler olacağını tanımlıyoruz 
          var allowedExtensios= new[]{".jpg",".jpeg",".png"};
        // seçilen resmin sonundaki .jpg bilgisini alır
          extension = Path.GetExtension(imageFile.FileName);


            if(!allowedExtensios.Contains(extension)){
                ModelState.AddModelError("" , "geçerli bir resim seçiniz");

            }
        }

        if (ModelState.IsValid)
        {


            if(imageFile  !=null){
               
         var randomFileName =  string.Format($"{Guid.NewGuid().ToString()}{extension}"); 


        
         var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/assets/img", randomFileName);


            using(var stream =new FileStream(path, FileMode.Create))
            {
              await imageFile!.CopyToAsync(stream);
            }
               
             model.Resim = randomFileName;

 

            
            _datacontext.Aboats.Add(model);
            await _datacontext.SaveChangesAsync();

          
            return RedirectToAction("privacy","Home");
            }
         
        }
      
       
        
    
        return View(model);


    }


            public async Task<IActionResult> AboutList(){


              return View(
            new AnaViewModel(){
                Abouts = await  _datacontext.Aboats.ToListAsync(),
                Factss = await _datacontext.Facts.ToListAsync(),
                Progres = await _datacontext.Progres.ToListAsync(),
                Galeri =await _datacontext.Galeris.ToListAsync()
            }
        );
            

    }








        public IActionResult AboutEdit(int? id){

         if(id ==null){

         return NotFound();
         }
        var entity = _datacontext.Aboats.FirstOrDefault(p => p.AboutId == id);

        if(entity == null){


        return NotFound();
     }

       return View(entity);
}

[HttpPost]
 
  public async Task<IActionResult> AboutEdit(int? id , About model , IFormFile? imageFile){
   
    if(id != model.AboutId){
        return NotFound();
    }
    if(ModelState.IsValid){
        
            if(imageFile  !=null){
                var extension ="";
                 if(imageFile != null){

          var allowedExtensios= new[]{".jpg",".jpeg",".png"};
        
          extension = Path.GetExtension(imageFile.FileName);
            if(!allowedExtensios.Contains(extension)){
                ModelState.AddModelError("" , "geçerli bir resim seçiniz");

            }
               
             var randomFileName =  string.Format($"{Guid.NewGuid().ToString()}{extension}"); 
             var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/assets/img", randomFileName);
            using(var stream =new FileStream(path, FileMode.Create))
            
            {
              await imageFile!.CopyToAsync(stream);
            }
               
             model.Resim = randomFileName;
          
            }
                 _datacontext.Update(model);
                await _datacontext.SaveChangesAsync();

            return RedirectToAction("AboutList");
    }
   

  }
   return View(model);
  }

  public IActionResult FactsCreate(){

    return View();
  }

  [HttpPost]
  public async Task<IActionResult>FactsCreate (Facts model){

    if(ModelState.IsValid){

      _datacontext.Facts.Add(model);
      await _datacontext.SaveChangesAsync();
      return RedirectToAction("Privacy","Home");
    }

    return View(model);
  }


    public IActionResult Progres(){

    return View();
  }

  [HttpPost]
   public async Task<IActionResult>Progres (Progres model){

    if(ModelState.IsValid){

      _datacontext.Progres.Add(model);
      await _datacontext.SaveChangesAsync();
      return RedirectToAction("Privacy","Home");
    }

    return View(model);
  }

    public IActionResult GaleriCreate(){
    return View();
}

[HttpPost]
 public async Task<IActionResult> GaleriCreate(Galeri model, IFormFile imageFile)
    {   
       
          var extension="";
        if(imageFile != null){
          var allowedExtensios= new[]{".jpg",".jpeg",".png"}; 
          extension = Path.GetExtension(imageFile.FileName);
            if(!allowedExtensios.Contains(extension)){
                ModelState.AddModelError("" , "geçerli bir resim seçiniz");
            }
        }

        if (ModelState.IsValid)
        {
         if(imageFile  !=null){  
         var randomFileNamee =  string.Format($"{Guid.NewGuid().ToString()}{extension}"); 
         var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/assets/galeri", randomFileNamee);
            using(var stream =new FileStream(path, FileMode.Create))
            {
              await imageFile!.CopyToAsync(stream);
            }
             model.Resim = randomFileNamee;
            _datacontext.Galeris.Add(model);
            await _datacontext.SaveChangesAsync();

          
            return RedirectToAction("AboutList","Admin");
            }
         
        }
    
        return View(model);


    }


        public IActionResult GaleriEdit(int? id){

         if(id ==null){

         return NotFound();
     }
        var entity = _datacontext.Galeris.FirstOrDefault(p => p.GaleriId == id);

        if(entity == null){


        return NotFound();
     }

       return View(entity);
}

   [HttpPost]
   public async Task<IActionResult> GaleriEdit(int? id , Galeri model , IFormFile imageFile){
   
    if(id != model.GaleriId){
        return NotFound();
    }
    if(ModelState.IsValid){
        
            if(imageFile  !=null){
                var extension ="";
                 if(imageFile != null){

          var allowedExtensios= new[]{".jpg",".jpeg",".png"};
        
          extension = Path.GetExtension(imageFile.FileName);
            if(!allowedExtensios.Contains(extension)){
                ModelState.AddModelError("" , "geçerli bir resim seçiniz");

            }
               
             var randomFileName =  string.Format($"{Guid.NewGuid().ToString()}{extension}"); 
             var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/assets/galeri", randomFileName);
            using(var stream =new FileStream(path, FileMode.Create))
            
            {
              await imageFile!.CopyToAsync(stream);
            }
               
             model.Resim = randomFileName;
          
            }
                 _datacontext.Update(model);
                await _datacontext.SaveChangesAsync();

            return RedirectToAction("AboutList");
    }
   

  }
   return View(model);
  }




  
  



}


  

