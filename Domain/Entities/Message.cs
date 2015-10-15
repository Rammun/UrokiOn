using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }

        /// <summary>
        /// От кого сообщение
        /// </summary>
        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Дата создания сообщения
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Флаг: входящее или исходящее сообщение
        /// </summary>
        public bool InOut { get; set; }

        /// <summary>
        /// Статус сообщения прочитано или нет
        /// </summary>
        public bool Status { get; set; }
    }
}
