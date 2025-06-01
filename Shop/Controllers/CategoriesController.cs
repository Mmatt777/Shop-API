using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories;

namespace Shop.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoriesController(ICategoriesService categoriesService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoriesService.GetAllCategory();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute]int id)
        {
            var category = await categoriesService.GetCategoryById(id);
            if (category is null)
                return NotFound();

            return Ok(category);
        }
    }
}
