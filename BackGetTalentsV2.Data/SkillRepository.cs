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
        // private CategoryRepository _categoryRepository;
        // private ICategoryRepository _categoryRepository;

        public SkillRepository(gettalentsContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            // _categoryRepository = new CategoryRepository(dbContext);
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
            return _dbContext.Skills.Include(u => u.Category).Include(u => u.UserHasSkills).ThenInclude(u => u.User).ToList();
        }

        public Skill GetSkillById(int id)
        {
            Skill skill = _dbContext.Skills.Where(c => c.Idskill.Equals(id)).Include(u => u.Category).Include(u => u.UserHasSkills).FirstOrDefault();

            if (skill == null)
            {
                throw new SkillNotFoundException();
            }

            // Category category = _categoryRepository.GetCategoryById(skill.CategoryId);
            // skill.Category = category;

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