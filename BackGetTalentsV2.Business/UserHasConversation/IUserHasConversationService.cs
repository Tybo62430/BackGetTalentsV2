using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.UserHasConversation
{
    public interface IUserHasConversationService
    {
        UserHasConversation NewUserHasConversation(UserHasConversation userHasConversation);
    }
}
