using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackGetTalentsV2.Business.Category;

namespace BackGetTalentsV2.Business.Skill
{
    public class SkillDTOForUser
    {
        public int Idskill { get; set; }
        public string Name { get; set; }
        public virtual CategoryDTOMinimalist Category { get; set; }
    }
}
