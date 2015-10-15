using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    /// <summary>
    /// Роли в группе
    /// </summary>
    public class MemberRole
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage="Введите название роли")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
