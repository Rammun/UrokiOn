using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetGroups();
        Group GetGroupById(int id);
        IEnumerable<Group> GetGroupsByAdministratorId(string id);
        IEnumerable<Group> GetGroupsByTypeId(int id);
        void AddGroup(Group group);
        void DelGroup(Group group);
    }
}
