using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;

namespace BusinessLogic.Implementaions
{
    public class EFRegionRepository : IRegionRepository
    {
        private ApplicationDbContext context;
        public EFRegionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Region> GetRegions()
        {
            return context.Regions;
        }

        public IEnumerable<Region> GetRegionsByCountryId(int id)
        {
            return context.Regions.Where(x => x.CountryId == id);
        }

        public IEnumerable<string> GetRegionNames()
        {
            return context.Regions.AsQueryable().Select(x => x.Name);
        }

        public IEnumerable<string> GetRegionNamesByIdCountry(int id)
        {
            return context.Regions.AsQueryable().Where(x => x.Id == id).Select(x => x.Name);
        }

        public Region GetRegionByID(int id)
        {
            return context.Regions.FirstOrDefault(x => x.Id == id);
        }

        public Region GetRegionByName(string name)
        {
            return context.Regions.FirstOrDefault(x => x.Name == name);
        }

        public void AddRegion(Region region)
        {
            context.Regions.Add(region);
            context.SaveChanges();
        }

        public void DelRegion(Region region)
        {
            context.Regions.Remove(region);
            context.SaveChanges();
        }
    }
}
