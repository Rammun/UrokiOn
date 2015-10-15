using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class WallOfUser
    {
        public int Id { get; set; }

        /// <summary>
        /// Пользователь стены
        /// </summary>
        public virtual ApplicationUser User { get; set; }
        public int UserId { get; set; }

        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
    }
}
