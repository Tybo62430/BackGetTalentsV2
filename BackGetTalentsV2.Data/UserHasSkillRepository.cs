using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackGetTalentsV2.Business.UserHasSkill;
using BackGetTalentsV2.Business.Category;
using Microsoft.EntityFrameworkCore;

namespace BackGetTalentsV2.Data
{
    public class UserHasSkillRepository : IUserHasSkillRepository
    {
        private gettalentsContext _dbContext;

        public UserHasSkillRepository(gettalentsContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Create(UserHasSkill userHasSkill)
        {
            if (userHasSkill == null)
            {
                throw new ArgumentNullException(nameof(userHasSkill));
            }

            _dbContext.UserHasSkills.Add(userHasSkill);
            _dbContext.SaveChanges();
        }

        public IList<UserHasSkill> GetAllUserHasSkills()
        {
            return _dbContext.UserHasSkills.Include(u => u.SkillIdskillNavigation).Include(u => u.User).ToList();
        }

        public UserHasSkill GetUserHasSkillByUserId(int userId)
        {
            UserHasSkill userHasSkill = _dbContext.UserHasSkills.Where(c => c.UserId.Equals(userId)).FirstOrDefault();

            if (userHasSkill == null)
            {
                throw new UserHasSkillNotFoundException();
            }

            return userHasSkill;

        }

        public UserHasSkill GetUserHasSkillBySkillIdskill(int skillIdskill)
        {
            UserHasSkill userHasSkill = _dbContext.UserHasSkills.Where(c => c.SkillIdskill.Equals(skillIdskill)).FirstOrDefault();

            if (userHasSkill == null)
            {
                throw new UserHasSkillNotFoundException();
            }

            return userHasSkill;

        }

        public void Update(UserHasSkill userHasSkill)
        {
            if (userHasSkill == null)
            {
                throw new ArgumentNullException(nameof(userHasSkill));
            }

            if (GetUserHasSkillByUserId(userHasSkill.UserId) != null)
            {
                _dbContext.UserHasSkills.Update(userHasSkill);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(UserHasSkill userHasSkill)
        {
            if (userHasSkill == null)
            {
                throw new ArgumentNullException(nameof(userHasSkill));
            }

            if (GetUserHasSkillByUserId(userHasSkill.UserId) != null)
            {
                _dbContext.UserHasSkills.Remove(userHasSkill);
                _dbContext.SaveChanges();
            }
        }

    }
}