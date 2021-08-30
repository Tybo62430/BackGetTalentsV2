using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Convers
{
    class ConversationService : IConversationService
    {
        private IConversationRepository iconversationRepository;

        public ConversationService(IConversationRepository iconversationRepository)
        {
            this.iconversationRepository = iconversationRepository;
        }

        public ICollection<Conversation> FindAllConversationByUserId(int userId)
        {
            return this.iconversationRepository.FindAllConversationByUserId(userId);
        }
    }
}
