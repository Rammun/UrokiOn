using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;

namespace BusinessLogic.Implementaions
{
    public class EFCityRepository : ICityRepository
    {
        private ApplicationDbContext context;
        public EFCityRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<City> GetCitys()
        {
            return context.Cities;
        }

        public IEnumerable<City> GetCitysByRegionId(int id)
        {
            return context.Cities.Where(x => x.RegionId == id);
        }

        public IEnumerable<string> GetCityNames()
        {
            return context.Cities.AsQueryable().Select(x => x.Name);
        }

        public IEnumerable<string> GetCityNamesByIdRegion(int id)
        {
            return context.Cities.AsQueryable().Where(x => x.RegionId == id).Select(x => x.Name);
        }

        public City GetCityByID(int id)
        {
            return context.Cities.Find(id);
        }

        public City GetCityByName(string name)
        {
            return context.Cities.FirstOrDefault(x => x.Name == name);
        }

        public void AddCity(City city)
        {
            context.Cities.Add(city);
            context.SaveChanges();
        }

        public void RemoveCity(City city)
        {
            context.Cities.Remove(city);
            context.SaveChanges();
        }
    }
}
