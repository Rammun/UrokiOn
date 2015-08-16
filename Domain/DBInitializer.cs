using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // ---->  Создание пользователя
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            ApplicationUser user = new ApplicationUser()
            {
                Email = "admin@adm.ru",
                UserName = "admin@adm.ru"
            };
            user.EmailConfirmed = true;
            userManager.Create(user, "password");

            IdentityRole role = new IdentityRole("admin");
            roleManager.Create(role);
            userManager.AddToRole(user.Id, role.Name);

            UserProfile userProfile = new UserProfile
            {
                Name = "Руслан",
                Surname = "Лихобаба",
                MiddleName = "Сергеевич"
            };
            user.UserProfile = userProfile;
            context.UserProfiles.Add(userProfile);            
            // <----

            context.SaveChanges();

        }
    }
}
