﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserProfile
    {
        public string Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }

        public DateTime? Birthday { get; set; }

        public virtual City City { get; set; }
        public int? CityId { get; set; }

        public virtual Region Region { get; set; }
        public int? RegionId { get; set; }
        
        public virtual Country Country { get; set; }
        public int? CountryId { get; set; }

        /// <summary>
        /// Стена пользователя
        /// </summary>
        public virtual WallOfUser WallOfUser { get; set; }
        public int? WallOfUserId { get; set; }

        /// <summary>
        /// Друзья пользователя
        /// </summary>
        public virtual ICollection<ApplicationUser> FriendUsers { get; set; }

        /// <summary>
        /// Запросы в друзья
        /// </summary>
        public virtual ICollection<FriendRequest> FriendRequests { get; set; }

        /// <summary>
        /// Запросы пользователя в группы
        /// </summary>
        public virtual ICollection<RequestGU> RequestGUs { get; set; }

        /// <summary>
        /// Группы, в которых сосотоит пользователь
        /// </summary>
        public virtual ICollection<Group> Groups { get; set; }

        /// <summary>
        /// Входящие и исходящие сообщения
        /// </summary>
        public virtual ICollection<Message> Messages { get; set; }

                
        public UserProfile()
        {
            FriendUsers = new List<ApplicationUser>();
            FriendRequests = new List<FriendRequest>();
            Groups = new List<Group>();
            Messages = new List<Message>();
            RequestGUs = new List<RequestGU>();
        }
    }
}
