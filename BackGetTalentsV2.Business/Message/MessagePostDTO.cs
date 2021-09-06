using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Message
{
    public class MessagePostDTO
    {
        //public int Id { get; set; }
        public string Content { get; set; }
        public int SenderId { get; set; }
        public int ReciverId { get; set; }
        //public int ConversationId { get; set; }
    }
}
