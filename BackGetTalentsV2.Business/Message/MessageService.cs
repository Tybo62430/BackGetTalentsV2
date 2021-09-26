using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Message
{
    public class MessageService : IMessageService
    {
        private IMessageRepository imessageRepository;

        public MessageService(IMessageRepository imessageRepository)
        {
            this.imessageRepository = imessageRepository;
        }

        public Message AddMessage(Message message)
        {
            this.imessageRepository.AddMessage(message);

            return message;
        }

        public ICollection<Message> FindAllMessagesByConversationId(int conversationId)
        {
            ICollection<Message> messages = this.imessageRepository.FindAllMessagesByConversationId(conversationId);

            return messages;
        }

        public Message FindLastMessageByConversationId(int conversationId)
        {
            Message message = this.imessageRepository.FindLastMessageByConversationId(conversationId);

            return message;
        }
    }
}
