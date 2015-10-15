using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;

namespace BusinessLogic.Implementaions
{
    public class EFGroupNewseRepository : IGroupNewseRepository
    {
        private ApplicationDbContext context;
        public EFGroupNewseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Article> GetGroupNewses()
        {
            return context.Articles;
        }

        public Article GetGroupNewsById(int id)
        {
            return context.Articles.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Article> GetGroupNewsByGroupId(int id)
        {
            return context.Articles.Where(x => x.GroupId == id);
        }

        public Article GetGroupNewsByDate(DateTime date)
        {
            return context.Articles.FirstOrDefault(x => x.CreateDate == date);
        }

        public void AddGroupNews(Article news)
        {
            throw new NotImplementedException();
        }

        public void DelGroupNews(Article news)
        {
            throw new NotImplementedException();
        }
    }
}
