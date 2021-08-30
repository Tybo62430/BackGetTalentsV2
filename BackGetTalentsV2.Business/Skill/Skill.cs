using System;
using System.Collections.Generic;

#nullable disable

namespace BackGetTalentsV2.Business.Skill
{
    public partial class Skill
    {
        public Skill()
        {
            UserHasSkills = new HashSet<UserHasSkill.UserHasSkill>();
        }

        public int Idskill { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public virtual Category.Category Category { get; set; }
        public virtual ICollection<UserHasSkill.UserHasSkill> UserHasSkills { get; set; }
    }
}
