using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetMessages();
        Message GetIncomingMessagesById(int id);
        IEnumerable<Message> GetIncomingMessagesByUserId(string id);
        IEnumerable<Message> GetOutgoingMessagesByUserId(string id);
        void AddMessage(Message message);
        void DelMessage(Message message);
    }
}
