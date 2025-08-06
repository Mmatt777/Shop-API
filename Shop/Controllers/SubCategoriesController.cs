using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.SubCategories.Commands.CreateSubCategory;
using Shop.Application.SubCategories.Commands.DeleteSubCategory;
using Shop.Application.SubCategories.Commands.UpdateSubCategory;
using Shop.Application.SubCategories.DTOS;
using Shop.Application.SubCategories.Queries.GetAllSubcategoriesByIdForCategory;
using Shop.Application.SubCategories.Queries.GetSubCategoryById;
using Shop.Domain.Constants;
using Shop.Infrastructure.Authorization;


namespace Shop.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/category/{categoryId}/subcategories")]
    public class SubCategoriesController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<SubCategoryDTO>>> GetAllSubcategoriesForCategory([FromRoute] int categoryId)
        {
            var subCategory = await mediator.Send(new GetSubCategoriesForCategoryQuery(categoryId));

            return Ok(subCategory);
        }
        
        [HttpGet("{subCategoryId}")]
        [Authorize(Policy = PolitycyNames.HasCountry)]
        //[AllowAnonymous]
        public async Task<ActionResult<SubCategoryDTO>> GetSubcategoryByIdForCategory([FromRoute] int categoryId, [FromRoute] int subCategoryId)
        {
            var subCategory = await mediator.Send(new GetSubcategoryByIdForCategoryQuery(categoryId, subCategoryId));

            return Ok(subCategory);
        }

        [HttpPost]
        [Authorize(Roles = IdentityRoles.Admin)]
        public async Task<IActionResult> CreateSubCategories([FromRoute] int categoryId, CreateSubCategoryForCategoryCommand createSubCategoryCommnad)
        {
            createSubCategoryCommnad.CategoryId = categoryId;
            var subcategoryId = await mediator.Send(createSubCategoryCommnad);
            return CreatedAtAction(nameof(GetSubcategoryByIdForCategory), new {categoryId, subcategoryId}, null);
        }

        [HttpPatch("{subCategoryId}")]
        [Authorize(Roles = IdentityRoles.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSubCategory([FromRoute] int categoryId, [FromRoute] int subCategoryId, UpdateSubCategoryForCategoryCommand command)
        {
            command.CategoryId = categoryId;
            command.SubCategoryId = subCategoryId;
            await mediator.Send(command);

                return NoContent();
        }

        [HttpDelete("{subCategoryId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSubCategoryForCategory([FromRoute] int categoryId, [FromRoute] int subCategoryId)
        {
            await mediator.Send(new DeleteSubCategoryForCategoryCommand(categoryId, subCategoryId));
            
                return NoContent();
        }
        
        
    }
}
