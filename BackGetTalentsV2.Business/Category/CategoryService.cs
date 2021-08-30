using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Category
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void AddCategory(Category category)
        {
            _categoryRepository.Create(category);
        }

        public IList<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            Category category = _categoryRepository.GetCategoryById(id);

            if (category == null)
            {
                throw new CategoryNotFoundException();
            }

            return category;

        }

        public void UpdateCategory(int id, Category category)
        {
            Category tempCategory = _categoryRepository.GetCategoryById(id);

            if (tempCategory == null)
            {
                throw new CategoryNotFoundException();
            }

            _categoryRepository.Update(category);

        }

        public void DeleteCategory(int id)
        {
            Category category = _categoryRepository.GetCategoryById(id);

            if (category == null)
            {
                throw new CategoryNotFoundException();
            }

            _categoryRepository.Delete(category);
        }

    }
}