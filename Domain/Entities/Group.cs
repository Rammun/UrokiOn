using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Группы созданные пользователями
    /// </summary>
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Родительская группа. Если null, то группа не имеет родителя
        /// </summary>
        public virtual Group ParentGroup { get; set; }
        public int? ParentGroupId { get; set; }

        /// <summary>
        /// Профайл группы
        /// </summary>
        public virtual GroupProfile GroupProfile { get; set; }
        public int? GroupProfileId { get; set; }

        /// <summary>
        /// Тип группы
        /// </summary>
        public virtual GroupType GroupType { get; set; }
        public int GroupTypeId { get; set; }

        /// <summary>
        /// Администратор группы
        /// </summary>
        public virtual ApplicationUser Administrator { get; set; }
        public string AdministratorId { get; set; }

        /// <summary>
        /// Коллекция пользователей группы
        /// </summary>
        public virtual ICollection<ApplicationUser> Users { get; set; }

        /// <summary>
        /// Коллекция новостей группы
        /// </summary>
        public virtual ICollection<GroupNewse> GroupNewses { get; set; }

        /// <summary>
        /// Коллекция дочерних групп
        /// </summary>
        public virtual ICollection<Group> ChildGroups { get; set; }

        /// <summary>
        /// Коллекция запросов с приглашениями от групп и группам
        /// </summary>
        public virtual ICollection<RequestGG> RequestGGs { get; set; }

        /// <summary>
        /// Коллекция запросов с приглашениями от пользователей и пользователям
        /// </summary>
        public virtual ICollection<RequestGU> RequestGUs { get; set; }
        
        public Group()
        {
            GroupNewses = new List<GroupNewse>();
            ChildGroups = new List<Group>();
            RequestGGs = new List<RequestGG>();
        }

        public Group(string groupName, GroupType groupType, ApplicationUser admin) : this()
        {
            Name = groupName;
            GroupType = groupType;
            Administrator = admin;
        }
    }
}
