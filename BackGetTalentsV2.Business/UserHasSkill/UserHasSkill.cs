using System;
using System.Collections.Generic;

#nullable disable

namespace BackGetTalentsV2.Business.UserHasSkill
{
    public partial class UserHasSkill
    {
        public int UserId { get; set; }
        public int SkillIdskill { get; set; }

        public virtual Skill.Skill SkillIdskillNavigation { get; set; }
        public virtual User.User User { get; set; }
    }
}
