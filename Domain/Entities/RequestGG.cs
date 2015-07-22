using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Заявка группы на присоединение к группе
    /// </summary>
    public class RequestGG
    {
        public int Id { get; set; }

        /// <summary>
        /// Пользователь, подавший запрос
        /// </summary>
        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }

        /// <summary>
        /// Группа, которой принадлежит запрос
        /// </summary>
        public virtual Group GroupFrom { get; set; }
        public int GroupFromId { get; set; }


        /// <summary>
        /// Группа, которой направлен запрос
        /// </summary>
        public virtual Group GroupIn { get; set; }
        public int GroupInId { get; set; }

        /// <summary>
        /// Текст, сопровождающий запрос
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Дата создания заявки
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Входищий или исходящий запрос
        /// </summary>
        public bool InOut { get; set; }

        /// <summary>
        /// Блокировка запроса
        /// </summary>
        public bool Status { get; set; }
    }
}
