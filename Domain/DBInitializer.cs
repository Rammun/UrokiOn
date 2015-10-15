using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Text;

namespace Domain
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        private Random rnd = new Random();

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

            GroupType groupType = new GroupType("Администратор");
            groupType.Description = "Тип группы для сотрудников - администраторов";
            context.GroupTypes.Add(groupType);

            Group group = new Group("Админы", groupType, user);
            context.Groups.Add(group);

            for (int i = 0; i < 10; i++)
            {
                GroupNewse news = new GroupNewse
                {
                    Title = "Новость" + i,
                    CreateDate = DateTime.Now,
                    Status = true,
                    Text = CreatText(),
                    CountReader = 0,
                    Group = group
                };
                context.GroupNewses.Add(news);
            }

            context.SaveChanges();
        }

        private string CreatText()
        {
            StringBuilder text = new StringBuilder();
            int length = rnd.Next(1, 4) * 15;
            for (int i = 0; i < length; i++)
            {
                text.Append("текст").Append(i).Append(" ");
            }
            return text.ToString();
        }
    }
}