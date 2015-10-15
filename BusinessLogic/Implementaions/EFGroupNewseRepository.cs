using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Interfaces;
using DAL;
using DAL.Entities;

namespace BusinessLogic.Implementaions
{
    public class EFGroupNewseRepository : IGroupNewseRepository
    {
        private ApplicationDbContext context;
        public EFGroupNewseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<GroupNewse> GetGroupNewses()
        {
            return context.GroupNewses;
        }

        public GroupNewse GetGroupNewsById(int id)
        {
            return context.GroupNewses.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GroupNewse> GetGroupNewsByGroupId(int id)
        {
            return context.GroupNewses.Where(x => x.GroupId == id);
        }

        public GroupNewse GetGroupNewsByDate(DateTime date)
        {
            return context.GroupNewses.FirstOrDefault(x => x.CreateDate == date);
        }

        public void AddGroupNews(GroupNewse news)
        {
            throw new NotImplementedException();
        }

        public void DelGroupNews(GroupNewse news)
        {
            throw new NotImplementedException();
        }
    }
}
