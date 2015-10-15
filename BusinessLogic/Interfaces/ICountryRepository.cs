using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Entities;

namespace BusinessLogic.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<string> GetCountryNames();
        Country GetCountryByID(int id);
        Country GetCountryByName(string name);
        void AddCountry(Country country);
        void RemoveCountry(Country country);
    }
}
