using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.SubCategories.Commands.CreateSubCategory;
using Shop.Application.SubCategories.Commands.DeleteSubCategory;
using Shop.Application.SubCategories.Commands.UpdateSubCategory;
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateSubCategory([FromRoute] int id, UpdateSubCategoryCommand command)
        {
            command.Id = id;
            var isUpdated = await mediator.Send(command);

            if (isUpdated)
                return NoContent();

            return NotFound();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategory([FromRoute] int id)
        {
            var isDeleted = await mediator.Send(new DeleteSubCategoryCommand(id));

            if (isDeleted)
                return NoContent();

            return NotFound();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateSubCategories([FromBody] CreateSubCategoryCommnad createSubCategoryCommnad)
        {
            var id = await mediator.Send(createSubCategoryCommnad);
            return CreatedAtAction(nameof(GetSubCategoryByIdWithProduts), new {id}, null);
        }
    }
}
