using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Message
{
    public interface IMessageRepository
    {
        Message FindLastMessageByConversationId(int conversationId);
        ICollection<Message> FindAllMessagesByConversationId(int conversationId);
    }
}
