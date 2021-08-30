
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Skill
{
    public interface ISkillRepository
    {
        void Create(Skill skill);
        IList<Skill> GetAllSkills();
        Skill GetSkillById(int id);
        void Update(Skill skill);
        void Delete(Skill skill);
    }
}