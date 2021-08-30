using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Category
{
    public interface ICategoryRepository
    {
        void Create(Category category);
        IList<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void Update(Category category);
        void Delete(Category category);
    }
}