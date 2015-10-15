using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetUsers();
        ApplicationUser GetUserById(string id);
        string GetUserIdByName(string userName);
        ApplicationUser GetUserByUserName(string userName);
        ApplicationUser GetUserByEmail(string email);
        IEnumerable<ApplicationUser> GetUsersByLoginDate(DateTime date);
        IEnumerable<ApplicationUser> GetUsersByStatus(bool status);
    }
}
