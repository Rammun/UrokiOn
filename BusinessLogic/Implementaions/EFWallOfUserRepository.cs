using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Interfaces;
using DAL;
using DAL.Entities;

namespace BusinessLogic.Implementaions
{
    public class EFWallOfUserRepository : IWallOfUserRepository
    {
        private ApplicationDbContext context;

        public EFWallOfUserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<WallOfUser> GetUserWalls()
        {
            return context.WallOfUsers;
        }

        public WallOfUser GetUserWallById(int id)
        {
            return context.WallOfUsers.Find(id);
        }

        public WallOfUser GetUserWallByFromUserName(string userName)
        {
            return context.WallOfUsers.Find(context.Users);
        }

        public ApplicationUser GetUser()
        {
            throw new NotImplementedException();
        }

        public DateTime GetCreateDate()
        {
            throw new NotImplementedException();
        }

        public bool GetStatus()
        {
            throw new NotImplementedException();
        }

        public void AddWallOfUser()
        {
            throw new NotImplementedException();
        }

        public void DelWallOfUser()
        {
            throw new NotImplementedException();
        }
    }
}
