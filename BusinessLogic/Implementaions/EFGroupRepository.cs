using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using DAL;
using DAL.Entities;

namespace BusinessLogic.Implementaions
{
    public class EFGroupRepository : IGroupRepository
    {
        private ApplicationDbContext context;
        public EFGroupRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Group> GetGroups()
        {
            return context.Groups;
        }

        public Group GetGroupById(int id)
        {
            return context.Groups.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Group> GetGroupsByAdministratorId(string id)
        {
            return context.Groups.Where(x => x.AdministratorId == id);
        }

        public IEnumerable<Group> GetGroupsByTypeId(int id)
        {
            return context.Groups.Where(x => x.GroupTypeId == id);
        }

        public void AddGroup(Group group)
        {
            context.Groups.Add(group);
            context.SaveChanges();
        }

        public void DelGroup(Group group)
        {
            context.Groups.Remove(group);
            context.SaveChanges();
        }
    }
}
