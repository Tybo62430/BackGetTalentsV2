
using BackGetTalentsV2.Business.Address;
using BackGetTalentsV2.Business.Skill;
using BackGetTalentsV2.Business.UserHasSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirebaseUid { get; set; }
        public string Pseudo { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public virtual Picture.PictureDTO ProfilePicture { get; set; }
        public virtual ICollection<AddressDTO> Addresses { get; set; }
        public virtual ICollection<SkillDTOForUser> Skills { get; set; }
    }
}