using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Message
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? SendAt { get; set; }
        public int ConversationId { get; set; }
        public string UserPseudo { get; set; }
        public virtual ICollection<Picture.PictureDTO> Pictures { get; set; }
    }
}
