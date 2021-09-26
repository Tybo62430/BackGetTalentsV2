using System;
using System.Collections.Generic;

#nullable disable

namespace BackGetTalentsV2.Business.Message
{
    public partial class Message
    {
        public Message()
        {
            Pictures = new HashSet<Picture.Picture>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? SendAt { get; set; }
        public int UserId { get; set; }
        public int ConversationId { get; set; }
        public virtual Convers.Conversation Conversation { get; set; }
        public virtual User.User User { get; set; }
        public virtual ICollection<Picture.Picture> Pictures { get; set; }
    }
}
