using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;

namespace BusinessLogic.Implementaions
{
    public class EFGroupTypeRepository : IGroupTypeRepository
    {
        private ApplicationDbContext context;
        public EFGroupTypeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<GroupType> GetGroupTypes()
        {
            return context.GroupTypes;
        }

        public GroupType GetGroupTypeById(int id)
        {
            return context.GroupTypes.FirstOrDefault(x => x.Id == id);
        }

        public Domain.Entities.GroupType GetGroupTypeByName(string name)
        {
            return context.GroupTypes.FirstOrDefault(x => x.Name == name);
        }

        public void AddGroupType(GroupType groupType)
        {
            context.GroupTypes.Add(groupType);
            context.SaveChanges();
        }

        public void DelGroupType(GroupType groupType)
        {
            context.GroupTypes.Remove(groupType);
            context.SaveChanges();
        }
    }
}
