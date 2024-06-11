using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace neproje.Data
{
    public class IdentitySeedDatabase
    {
        private const string adminUser ="admin";   
     private const string adminPasword ="admin123";   

     public static async void IdentityTestUser (IApplicationBuilder app){
        var context  = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (context.Database.GetAppliedMigrations().Any()){

            context.Database.Migrate();
        }


        
        var UserManager  = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();

        var user = await UserManager.FindByNameAsync(adminUser);
        if (user == null) {

            user = new AppUser{ 
                FullName="Fatih Kaplan",
                UserName = adminUser,
                Email    = "admin@gmail.com",
                PhoneNumber ="444444444"
              };
              await UserManager.CreateAsync(user , adminPasword);
        }

     }   

    
    }
}