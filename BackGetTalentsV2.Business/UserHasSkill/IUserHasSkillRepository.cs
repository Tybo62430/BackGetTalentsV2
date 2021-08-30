using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.UserHasSkill
{
    public interface IUserHasSkillRepository
    {
        void Create(UserHasSkill userHasSkill);
        IList<UserHasSkill> GetAllUserHasSkills();
        UserHasSkill GetUserHasSkillByUserId(int userId);
        UserHasSkill GetUserHasSkillBySkillIdskill(int skillIdskill);
        void Update(UserHasSkill userHasSkill);
        void Delete(UserHasSkill userHasSkill);
    }
}