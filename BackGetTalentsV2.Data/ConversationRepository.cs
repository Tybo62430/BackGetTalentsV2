using BackGetTalentsV2.Business;
using BackGetTalentsV2.Business.Convers;
using BackGetTalentsV2.Business.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Data
{
    public  class ConversationRepository : IConversationRepository
    {
        private gettalentsContext context;

        public ConversationRepository(gettalentsContext context)
        {
            this.context = context;
        }

        public ICollection<Conversation> FindAllConversationByUserId(int userId)
        {
             ICollection<Conversation> conversations = this.context.Conversations
                .Where(c => c.UserHasConversations
                .Any(c => c.UserId.Equals(userId)))
                .Include(c => c.Messages)
                .Include(c => c.UserHasConversations)
                .ThenInclude(c => c.User)
                .ToList();

            return conversations;
        }

        public ICollection<string> FindAllUsersByConvervationId(int conversationId)
        {
            throw new NotImplementedException();
        }

        public Conversation FindConversationById(int conversationId)
        {
            Conversation conversation = this.context.Conversations.Where(c => c.Id.Equals(conversationId)).FirstOrDefault(); ;

            return conversation;
        }

        public Conversation NewConversation(Conversation conversation)
        {
            this.context.Conversations.Add(conversation);
            this.context.SaveChanges();

            return conversation;
        }
    }
}
