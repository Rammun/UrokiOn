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
    public class Article
    {
        public int Id { get; set; }

        /// <summary>
        /// Группа, которой принадлежит статья
        /// </summary>
        public virtual Group Group { get; set; }
        public int GroupId { get; set; }

        /// <summary>
        /// Заголовок статьи
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Автор статьи
        /// </summary>
        public virtual ApplicationUser Author { get; set; }
        public string AuthorId { get; set; }

        /// <summary>
        /// Дата создания статьи
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Кол-во прочтений статьи
        /// </summary>
        public int CountReader { get; set; }

        /// <summary>
        /// Статус, отображать или нет статью
        /// </summary>
        public bool Status { get; set; }

        public ICollection<Chapter> Chapters { get; set; }

        public Article()
        {
            Chapters = new HashSet<Chapter>();
        }
    }
}
