using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Convers
{
    public interface IConversationService
    {
        ICollection<Conversation> FindAllConversationByUserId(int userId);
        ICollection<string> FindAllUsersByConvervationId(int conversationId);
        Conversation NewConversation(Conversation conversation);
    }
}
