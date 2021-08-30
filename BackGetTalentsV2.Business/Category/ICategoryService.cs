
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Category
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        IList<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void UpdateCategory(int id, Category category);
        void DeleteCategory(int id);

    }
}
