using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Тип группы
    /// </summary>
    public class GroupType
    {
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Display(Name = "Название")]
        public string Name { get; set; }

        /// <summary>
        /// Описание группы
        /// </summary>
        [Display(Name = "Описание")]
        public string Description { get; set; }

        /// <summary>
        /// Коллекция групп с этим типом
        /// </summary>
        public virtual ICollection<Group> Groups { get; set; }

        public GroupType()
        {
            Groups = new List<Group>();
        }

        public GroupType(string groupName) : this()
        {
            Name = groupName;
        }
    }
}
