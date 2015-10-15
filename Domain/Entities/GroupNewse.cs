using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Новости группы
    /// </summary>
    public class GroupNewse
    {
        public int Id { get; set; }

        /// <summary>
        /// Группа, которой принадлежит новость
        /// </summary>
        public virtual Group Group { get; set; }
        public int GroupId { get; set; }

        /// <summary>
        /// Заголовок новости
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Текст новости
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Дата создания новости
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Кол-во прочтений новости
        /// </summary>
        public int CountReader { get; set; }

        /// <summary>
        /// Статус, отображать или нет новость
        /// </summary>
        public bool Status { get; set; }
    }
}
