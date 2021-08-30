using System;
using System.Collections.Generic;

#nullable disable

namespace BackGetTalentsV2.Business.Convers
{
    public partial class Conversation
    {
        public Conversation()
        {
            Messages = new HashSet<Message.Message>();
            UserHasConversations = new HashSet<UserHasConversation.UserHasConversation>();
        }

        public int Id { get; set; }

        public virtual ICollection<Message.Message> Messages { get; set; }
        public virtual ICollection<UserHasConversation.UserHasConversation> UserHasConversations { get; set; }
    }
}
