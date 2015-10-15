using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IWallOfUserRepository
    {
        IEnumerable<WallOfUser> GetUserWalls();
        WallOfUser GetUserWallById(int id);
        WallOfUser GetUserWallByFromUserName(string userName);
        ApplicationUser GetUser();
        DateTime GetCreateDate();
        bool GetStatus();
        void AddWallOfUser();
        void DelWallOfUser();
    }
}
