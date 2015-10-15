using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;

namespace BusinessLogic.Implementaions
{
    public class EFMessageRepository : IMessageRepository
    {
        private ApplicationDbContext context;
        public EFMessageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Message> GetMessages()
        {
            return context.Messages;
        }

        public Message GetIncomingMessagesById(int id)
        {
            return context.Messages.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Message> GetIncomingMessagesByUserId(string userId)
        {
            return context.Messages.Where(x => x.UserId == userId);
        }

        public IEnumerable<Message> GetOutgoingMessagesByUserId(string userId)
        {
            return context.Messages.Where(x => x.UserId == userId);
        }

        public void AddMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
        }

        public void DelMessage(Message message)
        {
            context.Messages.Remove(message);
            context.SaveChanges();
        }
    }
}
