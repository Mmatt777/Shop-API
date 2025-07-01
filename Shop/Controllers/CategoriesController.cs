using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.DTOS;
using Shop.Application.Categories.Queries.GetAllCategories;
using Shop.Application.Categories.Queries.GetCategoryByIdWithsubCategory;
using Shop.Application.SubCategories.DTOS;


namespace Shop.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll()
        {
            var categories = await mediator.Send(new GetAllCategoriesQuery());

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoryDTO>> GetCategoryByIdWithsubCategory([FromRoute]int id)
        {
            var category = await mediator.Send(new GetCategoryByIdWithsubCategoryQuery(id));

            return Ok(category);
        }


    }
}
