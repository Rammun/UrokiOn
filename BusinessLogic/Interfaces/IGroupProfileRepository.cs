using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IGroupProfileRepository
    {
        IEnumerable<GroupProfile> GetGroupProfiles();
        GroupProfile GetGroupProfileById(int id);
        GroupProfile GetGroupProfileByGroupId(int id);
        GroupProfile GetGroupProfileByName(string name);
        IEnumerable<GroupProfile> GetGroupProfilesByCountryId(int id);
        IEnumerable<GroupProfile> GetGroupProfilesByRegionId(int id);
        IEnumerable<GroupProfile> GetGroupProfilesByCityId(int id);
        void AddGroupProfile(GroupProfile groupProfile);
        void DelGroupProfile(GroupProfile groupProfile);
    }
}
