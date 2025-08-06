using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Brands.DTOS;
using Shop.Application.Brands.Queries.GetAllBrandsForCategory;
using Shop.Application.Brands.Queries.GetAllBrandsForSubcategoryWithCategory;
using Shop.Infrastructure.Authorization;

namespace Shop.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/category/{categoryId}/")]
    public class BrandsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("brands")]
        [Authorize(Policy = PolitycyNames.Over18YearsOld)]
        public async Task<ActionResult<IEnumerable<BrandDTO>>> GetAllBrandsForCategory([FromRoute] int categoryId)
        {
            var brands = await mediator.Send(new GetAllBrandsForCategoryQuery(categoryId));
            return Ok(brands);
        }

        [HttpGet("subcategory/{subcategoryId}/brands")]
        public async Task<ActionResult<IEnumerable<BrandDTO>>> GetAllBrandsForSubcategoryWithCategory([FromRoute] int categoryId, [FromRoute] int subcategoryId)
        {
            var brands = await mediator.Send(new GetAllBrandsForSubcategoryWithCategoryQuery(categoryId, subcategoryId));
            return Ok(brands);
        }

    }
}
