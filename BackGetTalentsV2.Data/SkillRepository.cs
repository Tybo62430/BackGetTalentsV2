using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackGetTalentsV2.Business.Skill;
using BackGetTalentsV2.Business.Category;
using Microsoft.EntityFrameworkCore;

namespace BackGetTalentsV2.Data
{
    public class SkillRepository : ISkillRepository
    {
        private gettalentsContext _dbContext;

        public SkillRepository(gettalentsContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Create(Skill skill)
        {
            if (skill == null)
            {
                throw new ArgumentNullException(nameof(skill));
            }

            _dbContext.Skills.Add(skill);
            _dbContext.SaveChanges();
        }

        public IList<Skill> GetAllSkills()
        {
            return _dbContext.Skills
                .Include(a => a.Category)
                .Include(a => a.UserHasSkills)
                .ThenInclude(b => b.User)
                .ThenInclude(b => b.Picture)
                .ToList();
        }

        public Skill GetSkillById(int id)
        {
            Skill skill = _dbContext.Skills
                .Where(a => a.Idskill.Equals(id))
                .Include(a => a.Category)
                .Include(a => a.UserHasSkills)
                .ThenInclude(b => b.User)
                .ThenInclude(b => b.Picture)
                .FirstOrDefault();

            if (skill == null)
            {
                throw new SkillNotFoundException();
            }

            return skill;

        }

        public void Update(Skill skill)
        {
            if (skill == null)
            {
                throw new ArgumentNullException(nameof(skill));
            }

            if (GetSkillById(skill.Idskill) != null)
            {
                _dbContext.Skills.Update(skill);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Skill skill)
        {
            if (skill == null)
            {
                throw new ArgumentNullException(nameof(skill));
            }

            if (GetSkillById(skill.Idskill) != null)
            {
                _dbContext.Skills.Remove(skill);
                _dbContext.SaveChanges();
            }
        }

    }
}