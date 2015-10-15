using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Запросы в друзья
    /// </summary>
    public class FriendRequest
    {
        public int Id { get; set; }

        /// <summary>
        /// Пользователь подавший запрос
        /// </summary>
        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }

        /// <summary>
        /// Пользователь, которому адресован запрос
        /// </summary>
        public virtual ApplicationUser RequestFriend { get; set; }
        public string RequestFriendId { get; set; }

        /// <summary>
        /// Сопровождающее запрос сообщение
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Дата создания запроса
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
