using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackGetTalentsV2.Business.Category;
using BackGetTalentsV2.Business.User;

namespace BackGetTalentsV2.Business.Skill
{
    public class SkillDTO
    {
        public int Idskill { get; set; }
        public string Name { get; set; }
        public virtual CategoryDTOMinimalist Category { get; set; }
        public virtual ICollection<UserDTOMinimalist> Users { get; set; }

    }
}
