using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IGroupNewseRepository
    {
        IEnumerable<Article> GetGroupNewses();
        Article GetGroupNewsById(int id);
        IEnumerable<Article> GetGroupNewsByGroupId(int id);
        Article GetGroupNewsByDate(DateTime date);
        void AddGroupNews(Article news);
        void DelGroupNews(Article news);
    }
}
