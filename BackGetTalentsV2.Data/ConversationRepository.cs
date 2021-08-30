using BackGetTalentsV2.Business;
using BackGetTalentsV2.Business.Convers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Data
{
    class ConversationRepository : IConversationRepository
    {
        private gettalentsContext context;

        public ConversationRepository(gettalentsContext context)
        {
            this.context = context;
        }
        public ICollection<Conversation> FindAllConversationByUserId(int userId)
        {
            return this.context.Conversations.ToList();
        }
    }
}
