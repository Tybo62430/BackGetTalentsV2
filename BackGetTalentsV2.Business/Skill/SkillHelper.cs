using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackGetTalentsV2.Business.Category;
using BackGetTalentsV2.Business.User;
using BackGetTalentsV2.Business.Picture;

namespace BackGetTalentsV2.Business.Skill
{
    public class SkillHelper
    {
        public static List<SkillDTO> ConvertSkills(List<Skill> skills)
        {
            return skills.ConvertAll(skill => ConvertSkill(skill));
        }
        public static SkillDTO ConvertSkill(Skill skill)
        {
            SkillDTO skillDTO = new()
            {
                Idskill = skill.Idskill,
                Name = skill.Name,
                Category = CategoryHelper.ConvertCategoryMinimalist(skill.Category),
                Users = skill.UserHasSkills.ToList().ConvertAll(userHasSkill => new UserDTOMinimalist
                {
                    Id = userHasSkill.User.Id,
                    Pseudo = userHasSkill.User.Pseudo,
                    RegistrationDate = userHasSkill.User.RegistrationDate,
                    Status = userHasSkill.User.Status,
                    Email = userHasSkill.User.Email,
                    Phone = userHasSkill.User.Phone,
                    Presentation = userHasSkill.User.Presentation,
                    Birthday = userHasSkill.User.Birthday,
                    Role = userHasSkill.User.Role,
                    ProfilePicture = PictureHelper.ConvertPicture(userHasSkill.User.Picture)
                })
            };

            return skillDTO;
        }
        public static List<SkillDTOForCategory> ConvertSkillsForCategory(List<Skill> skills)
        {
            return skills.ConvertAll(skill => ConvertSkillForCategory(skill));
        }
        public static SkillDTOForCategory ConvertSkillForCategory(Skill skill)
        {
            SkillDTOForCategory skillDTOForCategory = new()
            {
                Idskill = skill.Idskill,
                Name = skill.Name,
            };

            return skillDTOForCategory;
        }

        public static List<SkillDTOForUser> ConvertSkillsForUser(List<Skill> skills)
        {
            return skills.ConvertAll(skill => ConvertSkillForUser(skill));
        }
        public static SkillDTOForUser ConvertSkillForUser(Skill skill)
        {
            SkillDTOForUser skillDTOForUser = new()
            {
                Idskill = skill.Idskill,
                Name = skill.Name,
                Category = CategoryHelper.ConvertCategoryMinimalist(skill.Category)
            };

            return skillDTOForUser;
        }

        public static List<SkillDTOMinimalist> ConvertSkillsMinimalist(List<Skill> skills)
        {
            return skills.ConvertAll(skill => ConvertSkillMinimalist(skill));
        }
        public static SkillDTOMinimalist ConvertSkillMinimalist(Skill skill)
        {
            SkillDTOMinimalist skillDTOMinimalist = new()
            {
                Idskill = skill.Idskill,
                Name = skill.Name,
                Category = CategoryHelper.ConvertCategoryMinimalist(skill.Category)
            };

            return skillDTOMinimalist;
        }

        public static Skill ConvertSkillDTO(SkillDTOMinimalist skillDTO)
        {
            Skill skill = new()
            {
                Idskill = skillDTO.Idskill,
                Name = skillDTO.Name,
                Category = CategoryHelper.ConvertCategoryDTO(skillDTO.Category)
            };

            return skill;
        }
    }
}
