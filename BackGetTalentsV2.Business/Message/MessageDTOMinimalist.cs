using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Message
{
    public class MessageDTOMinimalist
    { 
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? SendAt { get; set; }
        public int ConversationId { get; set; }
    }
}
