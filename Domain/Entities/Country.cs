using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    /// <summary>
    /// Страна
    /// </summary>
    public class Country
    {
        public int Id { get; set; }

        [Display(Name="Название страны")]
        public string Name { get; set; }
        public string Alpha2 { get; set; }
        public string Alpha3 { get; set; }
        public string Iso { get; set; }
        public int Ordering { get; set; }

        /// <summary>
        /// Коллекция регионов страны
        /// </summary>
        [Display(Name = "Регионы в стране")]
        public virtual ICollection<Region> Regions { get; set; }

        /// <summary>
        /// Коллекция Городов страны
        /// </summary>
        [Display(Name = "Города в стране")]
        public virtual ICollection<City> Cities { get; set; }

        public virtual ICollection<GroupProfile> GroupProfiles { get; set; }

        public Country()
        {
            Regions = new List<Region>();
            Cities = new List<City>();
            GroupProfiles = new List<GroupProfile>();
        }
    }
}
