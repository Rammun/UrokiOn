using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserProfileRepository
    {
        IEnumerable<UserProfile> GetUserProfiles();
        UserProfile GetUserProfileById(int id);
        UserProfile GetUserProfileByUserId(string id);
        UserProfile GetUserProfileByUser(ApplicationUser User);
        void AddUserProfile(UserProfile userProfile);
        void DelUserProfile(UserProfile userProfile);
    }
}
