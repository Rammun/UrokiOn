using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IGroupTypeRepository
    {
        IEnumerable<GroupType> GetGroupTypes();
        GroupType GetGroupTypeById(int id);
        GroupType GetGroupTypeByName(string name);
        void AddGroupType(GroupType groupType);
        void DelGroupType(GroupType groupType);
    }
}
