using Domain.Entities;
using Microsoft.AspNet.Identity;
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
                UserName = "Admin"
            };
            IdentityRole role = new IdentityRole("admin");

            UserProfile userProfile = new UserProfile
            {
                Name = "Руслан",
                Surname = "Лихобаба",
                MiddleName = "Сергеевич"
            };

            user.UserProfile = userProfile;

            context.UserProfiles.Add(userProfile);
            userManager.Create(user, "qqqqqq");

            roleManager.Create(role);
            userManager.AddToRole(user.Id, role.Name);
            // <----
            context.SaveChanges();

        }
    }
}
