using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackGetTalentsV2.Business.Category;

namespace BackGetTalentsV2.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            _categoryService.AddCategory(category);
            return Created(nameof(CreateCategory), category);
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_categoryService.GetAllCategories());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCategoryById([FromRoute] int id)
        {
            try
            {
                Category category = _categoryService.GetCategoryById(id);

                return Ok(category);
            }
            catch (CategoryNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdateCategory([FromRoute] int id, [FromBody] Category category)
        {
            try
            {
                _categoryService.UpdateCategory(id, category);
                return NoContent();
            }
            catch (CategoryNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            try
            {
                _categoryService.DeleteCategory(id);
                return NoContent();
            }
            catch (CategoryNotFoundException)
            {
                return NotFound();
            }
        }

    }


}