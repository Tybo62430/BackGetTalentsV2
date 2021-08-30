
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Skill
{
    public interface ISkillService
    {
        void AddSkill(Skill skill);
        IList<Skill> GetAllSkills();
        Skill GetSkillById(int id);
        void UpdateSkill(int id, Skill skill);
        void DeleteSkill(int id);

    }
}