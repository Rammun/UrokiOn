using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Implementaions
{
    public class EFUserProfilRepository : IUserProfileRepository
    {
        private ApplicationDbContext context;
        public EFUserProfilRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<UserProfile> GetUserProfiles()
        {
            throw new NotImplementedException();
        }

        public UserProfile GetUserProfileById(int id)
        {
            throw new NotImplementedException();
        }

        public UserProfile GetUserProfileByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public UserProfile GetUserProfileByUser(ApplicationUser User)
        {
            throw new NotImplementedException();
        }

        public void AddUserProfile(UserProfile userProfile)
        {
            throw new NotImplementedException();
        }

        public void DelUserProfile(UserProfile userProfile)
        {
            throw new NotImplementedException();
        }
    }
}
