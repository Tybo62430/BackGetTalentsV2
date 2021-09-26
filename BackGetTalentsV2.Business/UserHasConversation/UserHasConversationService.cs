using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.UserHasConversation
{    
    public class UserHasConversationService : IUserHasConversationService
    {
        private IUserHasConversationRepository iuserHasConversationRepository;

        public UserHasConversationService(IUserHasConversationRepository iuserHasConversationRepository)
        {
            this.iuserHasConversationRepository = iuserHasConversationRepository;
        }

        public UserHasConversation NewUserHasConversation(UserHasConversation userHasConversation)
        {
            this.iuserHasConversationRepository.NewUserHasConversation(userHasConversation);

            return userHasConversation;
        }
    }
}
