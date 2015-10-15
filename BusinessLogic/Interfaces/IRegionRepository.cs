using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetRegions();
        IEnumerable<Region> GetRegionsByCountryId(int id);
        IEnumerable<string> GetRegionNames();
        IEnumerable<string> GetRegionNamesByIdCountry(int id);
        Region GetRegionByID(int id);
        Region GetRegionByName(string name);
        void AddRegion(Region region);
        void DelRegion(Region region);
    }
}
