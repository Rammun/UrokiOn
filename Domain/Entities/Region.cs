using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Region
    {
        public int Id { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        [Display(Name = "Название региона")]
        public string Name { get; set; }

        /// <summary>
        /// Принадлежность региона к стране
        /// </summary>
        [Display(Name = "В какой стране")]
        public virtual Country Country { get; set; }
        public int CountryId { get; set; }

        /// <summary>
        /// Коллекция городов в регионе
        /// </summary>
        [Display(Name = "Города в регионе")]
        public virtual ICollection<City> Cities { get; set; }

        public virtual ICollection<GroupProfile> GroupProfiles { get; set; }

        public Region()
        {
            Cities = new List<City>();
            GroupProfiles = new List<GroupProfile>();
        }
    }
}
