using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.User
{
    public class UserDTOMinimalist
    {
        public int Id { get; set; }
        public string FirebaseUid { get; set; }
        public string Pseudo { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public virtual Picture.PictureDTO ProfilePicture { get; set; }
    }
}