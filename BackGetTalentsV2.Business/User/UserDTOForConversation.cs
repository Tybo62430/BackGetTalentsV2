using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.User
{
    public class UserDTOForConversation
    {
        public int Id { get; set; }
        public string FirebaseUid { get; set; }
        public string Pseudo { get; set; }
    }
}
