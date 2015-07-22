using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;
using System;

namespace BusinessLogic.Implementaions
{
    public class EFCountryRepository : ICountryRepository
    {
        private ApplicationDbContext context;
        public EFCountryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Country> GetCountries()
        {
            return context.Countries;
        }

        public IEnumerable<string> GetCountryNames()
        {
            return context.Countries.AsQueryable().Select(x => x.Name);
        }

        public Country GetCountryByID(int id)
        {
            return context.Countries.FirstOrDefault(x => x.Id == id);
        }

        public Country GetCountryByName(string name)
        {
            return context.Countries.FirstOrDefault(x => x.Name == name);
        }

        public void AddCountry(Country country)
        {
            context.Countries.Add(country);
            context.SaveChanges();
        }

        public void DelCountry(Country country)
        {
            context.Countries.Remove(country);
            context.SaveChanges();
        }
    }
}
