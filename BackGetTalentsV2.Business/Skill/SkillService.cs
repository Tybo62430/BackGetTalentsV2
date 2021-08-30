using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackGetTalentsV2.Business.Category;

namespace BackGetTalentsV2.Business.Skill
{
    public class SkillService : ISkillService
    {
        private ISkillRepository _skillRepository;
        // private ICategoryRepository _categoryRepository;

        // public SkillService(ISkillRepository skillRepository, ICategoryRepository categoryRepository)
        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
            // _categoryRepository = categoryRepository;
        }

        public void AddSkill(Skill skill)
        {
            _skillRepository.Create(skill);
        }

        public IList<Skill> GetAllSkills()
        {
            return _skillRepository.GetAllSkills();
        }

        public Skill GetSkillById(int id)
        {
            Skill skill = _skillRepository.GetSkillById(id);

            if (skill == null)
            {
                throw new SkillNotFoundException();
            }

            // Category.Category category = _categoryRepository.GetCategoryById(skill.CategoryId);
            // skill.Category = category;

            return skill;

        }

        public void UpdateSkill(int id, Skill skill)
        {
            Skill tempSkill = _skillRepository.GetSkillById(id);

            if (tempSkill == null)
            {
                throw new SkillNotFoundException();
            }

            _skillRepository.Update(skill);

        }

        public void DeleteSkill(int id)
        {
            Skill skill = _skillRepository.GetSkillById(id);

            if (skill == null)
            {
                throw new SkillNotFoundException();
            }

            _skillRepository.Delete(skill);
        }

    }
}