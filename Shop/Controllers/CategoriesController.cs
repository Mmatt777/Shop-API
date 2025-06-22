using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.Queries.GetAllCategories;
using Shop.Application.Categories.Queries.GetCategoryByIdWithsubCategory;


namespace Shop.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoriesController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdWithsubCategory([FromRoute]int id)
        {
            var category = await mediator.Send(new GetCategoryByIdWithsubCategoryQuery(id));
            if (category is null)
                return NotFound();

            return Ok(category);
        }


    }
}
