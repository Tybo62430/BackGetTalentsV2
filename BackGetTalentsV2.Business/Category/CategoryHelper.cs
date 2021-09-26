using System;
using System.Collections.Generic;
using BackGetTalentsV2.Business.Picture;
using BackGetTalentsV2.Business.Skill;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Category
{
    public class CategoryHelper
    {
        public static List<CategoryDTO> ConvertCategories(List<Category> categories)
        {
            return categories.ConvertAll(category => ConvertCategory(category));
        }
        public static CategoryDTO ConvertCategory(Category category)
        {
            CategoryDTO categoryDTO = new()
            {
                Id = category.Id,
                Name = category.Name,
                CategoryPicture = PictureHelper.ConvertPicture(category.Picture),
                Skills = SkillHelper.ConvertSkillsForCategory(category.Skills.ToList())
            };

            return categoryDTO;
        }

        public static List<CategoryDTOMinimalist> ConvertCategoriesMinimalist(List<Category> categories)
        {
            return categories.ConvertAll(category => ConvertCategoryMinimalist(category));
        }
        public static CategoryDTOMinimalist ConvertCategoryMinimalist(Category category)
        {
            CategoryDTOMinimalist categoryDTOMinimalist = new()
            {
                Id = category.Id,
                Name = category.Name,
            };

            return categoryDTOMinimalist;
        }

        public static Category ConvertCategoryDTO(CategoryDTOMinimalist categoryDTO)
        {
            Category category = new()
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name
            };

            return category;
        }
    }
}
