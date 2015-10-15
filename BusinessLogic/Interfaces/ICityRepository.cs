using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
    public interface ICityRepository
    {
        IEnumerable<City> GetCitys();
        IEnumerable<City> GetCitysByRegionId(int id);
        IEnumerable<string> GetCityNames();
        IEnumerable<string> GetCityNamesByIdRegion(int id);
        City GetCityByID(int id);
        City GetCityByName(string name);
        void AddCity(City city);
        void RemoveCity(City city);
    }
}
