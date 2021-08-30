﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackGetTalentsV2.Business.Category;
using Microsoft.EntityFrameworkCore;

namespace BackGetTalentsV2.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private gettalentsContext _dbContext;

        public CategoryRepository(gettalentsContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Create(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public IList<Category> GetAllCategories()
        {
            // return _dbContext.Categories.ToList();
            return _dbContext.Categories.Include(u => u.Skills).ToList();
        }

        public Category GetCategoryById(int id)
        {
            // Category category = _dbContext.Categories.Where(c => c.Id.Equals(id)).FirstOrDefault();
            Category category = _dbContext.Categories.Where(c => c.Id.Equals(id)).Include(u => u.Skills).FirstOrDefault();

            if (category == null)
            {
                throw new CategoryNotFoundException();
            }

            return category;

        }

        public void Update(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            if (GetCategoryById(category.Id) != null)
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            if (GetCategoryById(category.Id) != null)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            }
        }

    }
}