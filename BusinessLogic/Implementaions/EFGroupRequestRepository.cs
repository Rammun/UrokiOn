using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Interfaces;
using DAL;
using DAL.Entities;

namespace BusinessLogic.Implementaions
{
    public class EFGroupRequestRepository : IGroupRequestRepository
    {
        private ApplicationDbContext context;
        public EFGroupRequestRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<RequestGG> GetGroupRequests()
        {
            return context.RequestGGs;
        }

        public bool RequestIsSent(int fromGroupId, int inGroupId)
        {

            return context.RequestGGs.Count(x => x.GroupInId == fromGroupId && x.Id == inGroupId) != 0;
        }

        public void AddGroupRequest(RequestGG groupRequest)
        {
            context.RequestGGs.Add(groupRequest);
            context.SaveChanges();
        }

        public void DeleteGroupRequest(RequestGG groupRequest)
        {
            context.RequestGGs.Remove(groupRequest);
            context.SaveChanges();
        }
    }
}
