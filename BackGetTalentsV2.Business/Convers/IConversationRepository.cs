using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Convers
{
    public interface IConversationRepository
    {
        ICollection<Conversation> FindAllConversationByUserId(int userId);
    }
}
