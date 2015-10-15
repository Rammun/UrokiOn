using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IGroupNewseRepository
    {
        IEnumerable<GroupNewse> GetGroupNewses();
        GroupNewse GetGroupNewsById(int id);
        IEnumerable<GroupNewse> GetGroupNewsByGroupId(int id);
        GroupNewse GetGroupNewsByDate(DateTime date);
        void AddGroupNews(GroupNewse news);
        void DelGroupNews(GroupNewse news);
    }
}
