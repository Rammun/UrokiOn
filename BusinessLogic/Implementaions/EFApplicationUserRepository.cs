using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Interfaces;
using DAL;
using DAL.Entities;
using System.Data;

namespace BusinessLogic.Implementaions
{
    public class EFApplicationUserRepository : IApplicationUserRepository
    {
        private ApplicationDbContext context;
        private ApplicationUser user;

        public EFApplicationUserRepository(ApplicationDbContext context)
        {
            this.context = context;
            //this.user = user;
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public string GetUserIdByName(string userName)
        {
            return user.Id;
        }

        public ApplicationUser GetUserByUserName(string login)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetUsersByLoginDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetUsersByStatus(bool status)
        {
            throw new NotImplementedException();
        }
    }
}
