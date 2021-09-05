using BackGetTalentsV2.Business.Message;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Data
{
    public class MessageRepository : IMessageRepository
    {
        private gettalentsContext context;

        public MessageRepository(gettalentsContext context)
        {
            this.context = context;
        }

        public Message AddMessage(Message message)
        {
            this.context.Messages.Add(message);
            this.context.SaveChanges();

            return message;
        }

        public ICollection<Message> FindAllMessagesByConversationId(int conversationId)
        {
            ICollection<Message> messages = this.context.Messages
                .Where(m => m.ConversationId.Equals(conversationId))
                .Include(m => m.User)
                .Include(m => m.Pictures)
                .ToList();

            return messages;
        }

        public Message FindLastMessageByConversationId(int conversationId)
        {
            Message message = this.context.Messages
                .Where(m => m.ConversationId
                .Equals(conversationId))
                .Include(m=> m.Conversation)
                .OrderByDescending(m => m.SendAt)
                .FirstOrDefault();

            return message;
        }
    }
}
