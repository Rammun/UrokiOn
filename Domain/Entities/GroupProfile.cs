using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    /// <summary>
    /// Профиль группы
    /// </summary>
    public class GroupProfile
    {
        public int Id { get; set; }

        /// <summary>
        /// Группа
        /// </summary>
        [Display(Name = "Группа")]
        public virtual Group Group { get; set; }
        public int GroupId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Display(Name="Название")]
        [Required(ErrorMessage="Введите название группы")]
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name="Описание")]
        public string Description { get; set; }

        /// <summary>
        /// Принадлежность к стране
        /// </summary>
        [Display(Name="Страна")]
        public virtual Country Country { get; set; }
        public int? CountryId { get; set; }

        /// <summary>
        /// Принадлежность к региону
        /// </summary>
        [Display(Name = "Регион")]
        public virtual Region Region { get; set; }
        public int? RegionId { get; set; }

        /// <summary>
        /// Принадлежность к городу
        /// </summary>
        [Display(Name = "Город")]
        public virtual City City { get; set; }
        public int? CityId { get; set; }
    }
}
