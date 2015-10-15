using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    /// <summary>
    /// Приглашения группы юзеру или юзера в группе
    /// </summary>
    public class RequestGU
    {
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public virtual Group Group { get; set; }
        public int GroupId { get; set; }

        public virtual ApplicationUser UserRequest { get; set; }
        public string UserRequestId { get; set; }

        public string Text { get; set; }
        public DateTime CreatDate { get; set; }
        public bool InOut { get; set; }
        public bool Status { get; set; }
    }
}
