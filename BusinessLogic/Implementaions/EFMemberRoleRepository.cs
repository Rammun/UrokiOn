using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Interfaces;
using DAL;
using DAL.Entities;

namespace BusinessLogic.Implementaions
{
    public class EFMemberRoleRepository : IMemberRoleRepository
    {
        private ApplicationDbContext context;
        public EFMemberRoleRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<MemberRole> GetMemberRoles()
        {
            return context.MemberRoles;
        }

        public MemberRole GetMemberRoleById(int id)
        {
            return context.MemberRoles.FirstOrDefault(x => x.Id == id);
        }

        public MemberRole GetMemberRoleByName(string name)
        {
            return context.MemberRoles.FirstOrDefault(x => x.Name == name);
        }

        public void AddMemberRole(MemberRole memberRole)
        {
            context.MemberRoles.Add(memberRole);
            context.SaveChanges();
        }

        public void DelMemberRole(MemberRole memberRole)
        {
            context.MemberRoles.Remove(memberRole);
            context.SaveChanges();
        }
    }
}
