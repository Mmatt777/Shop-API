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
    }
}
