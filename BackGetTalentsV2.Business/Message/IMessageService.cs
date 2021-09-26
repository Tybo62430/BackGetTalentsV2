using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Message
{
    public interface IMessageService
    {
        Message FindLastMessageByConversationId(int conversationId);
        ICollection<Message> FindAllMessagesByConversationId(int conversationId);
        Message AddMessage(Message message);
    }
}
