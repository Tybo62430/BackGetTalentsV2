using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Convers
{
    public class ConversationDTO
    {
        public int Id { get; set; }

        public ICollection<User.UserDTOForConversation> Users { get; set; }

        public DateTime DateLastMessage { get; set; }

        public string LastContent { get; set; }
    }
}
