using BackGetTalentsV2.Business.Convers;
using BackGetTalentsV2.Business.UserHasConversation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Data
{
    public class UserHasConversationRepository : IUserHasConversationRepository
    {
        private gettalentsContext context;

        public UserHasConversationRepository(gettalentsContext context)
        {
            this.context = context;
        }

        public UserHasConversation NewUserHasConversation(UserHasConversation userHasConversation)
        {
            this.context.UserHasConversations.Add(userHasConversation);
            this.context.SaveChanges();

            return userHasConversation;
        }
    }
}
