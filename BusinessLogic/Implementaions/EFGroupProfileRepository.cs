using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;

namespace BusinessLogic.Implementaions
{
    public class EFGroupProfileRepository : IGroupProfileRepository
    {
        private ApplicationDbContext context;
        public EFGroupProfileRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<GroupProfile> GetGroupProfiles()
        {
            return context.GroupProfiles;
        }

        public GroupProfile GetGroupProfileById(int id)
        {
            return context.GroupProfiles.FirstOrDefault(x => x.Id == id);
        }

        public GroupProfile GetGroupProfileByGroupId(int id)
        {
            //return context.GroupProfiles.FirstOrDefault(x => x.GroupId == id);
            throw new NotImplementedException();
        }

        public GroupProfile GetGroupProfileByName(string name)
        {
            return context.GroupProfiles.FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<GroupProfile> GetGroupProfilesByCountryId(int id)
        {
            return context.GroupProfiles.Where(x => x.CountryId == id);
        }

        public IEnumerable<GroupProfile> GetGroupProfilesByRegionId(int id)
        {
            return context.GroupProfiles.Where(x => x.RegionId == id);
        }

        public IEnumerable<GroupProfile> GetGroupProfilesByCityId(int id)
        {
            return context.GroupProfiles.Where(x => x.CityId == id); ;
        }

        public void AddGroupProfile(GroupProfile groupProfile)
        {
            context.GroupProfiles.Add(groupProfile);
            context.SaveChanges();
        }

        public void DelGroupProfile(GroupProfile groupProfile)
        {
            context.GroupProfiles.Remove(groupProfile);
            context.SaveChanges();
        }
    }
}
