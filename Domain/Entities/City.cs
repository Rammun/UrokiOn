using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Город
    /// </summary>
    public class City
    {
        public int Id { get; set; }

        [Display(Name="Название города")]
        public string Name { get; set; }

        /// <summary>
        /// Принадлежность к региону
        /// </summary>
        [Display(Name="В каком регионе")]
        public virtual Region Region { get; set; }
        public int RegionId { get; set; }

        /// <summary>
        /// Принадлежность к стране
        /// </summary>
        [Display(Name="В какой стране")]
        public virtual Country Country { get; set; }
        public int CountryId { get; set; }

        public virtual ICollection<GroupProfile> GroupProfiles { get; set; }

        public City()
        {
            GroupProfiles = new List<GroupProfile>();
        }
    }
}
