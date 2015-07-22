using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IMemberRoleRepository
    {
        IEnumerable<MemberRole> GetMemberRoles();
        MemberRole GetMemberRoleById(int id);
        MemberRole GetMemberRoleByName(string name);
        void AddMemberRole(MemberRole memberRole);
        void DelMemberRole(MemberRole memberRole);
    }
}
