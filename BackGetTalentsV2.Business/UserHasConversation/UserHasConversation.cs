using System;
using System.Collections.Generic;

#nullable disable

namespace BackGetTalentsV2.Business.UserHasConversation
{
    public partial class UserHasConversation
    {
        public int UserId { get; set; }
        public int ConversationId { get; set; }

        public virtual Convers.Conversation Conversation { get; set; }
        public virtual User.User User { get; set; }
    }
}
