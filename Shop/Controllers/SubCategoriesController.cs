using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.SubCategories.Commands.CreateSubCategory;
using Shop.Application.SubCategories.Queries.GetSubCategoryById;


namespace Shop.API.Controllers
{
    [ApiController]
    [Route("SubCategories")]
    public class SubCategoriesController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubCategoryByIdWithProduts([FromRoute] int id)
        {
            var subCategory = await mediator.Send(new GetSubCategoryByIdQuery(id));

            if (subCategory == null)
                return NotFound();

            return Ok(subCategory);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateSubCategories([FromBody] CreateSubCategoryCommnad createSubCategoryCommnad)
        {
            var id = await mediator.Send(createSubCategoryCommnad);
            return CreatedAtAction(nameof(GetSubCategoryByIdWithProduts), new {id}, null);
        }
    }
}
