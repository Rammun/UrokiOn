using System;
using System.Linq;
using System.Collections.Generic;
using Domain;
using BusinessLogic.Interfaces;
using Domain.Entities;

namespace BusinessLogic.Implementaions
{
    public class EFFriendRequestRepository : IFriendRequestRepository
    {
        private ApplicationDbContext context;
        public EFFriendRequestRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<FriendRequest> GetFriendRequests()
        {
            return context.FriendRequests;
        }

        public bool RequestIsSent(string userFromId, string userToId)
        {
            return context.FriendRequests.Count(x => x.UserId == userFromId && x.RequestFriendId == userToId) != 0;
        }

        public void AddFriendRequest(FriendRequest friendRequest)
        {
            context.FriendRequests.Add(friendRequest);
            context.SaveChanges();
        }

        public void DeleteFriendRequest(FriendRequest friendRequest)
        {
            context.FriendRequests.Remove(friendRequest);
            context.SaveChanges();
        }
    }
}
