using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products.DTOS;
using Shop.Application.Products.Queries.GetAllProductForCategoryQuery;
using Shop.Application.Products.Queries.GetAllProductForCategoryWithSubCategoryAndBrand;
using Shop.Application.Products.Queries.GetAllProductsForCategoryWithSubCategory;

namespace Shop.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/category/{categoryId}/")]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpGet("products")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProductsForCategory([FromRoute] int categoryId)
        {
            var products = await mediator.Send(new GetAllProductsForCategoryQuery(categoryId));
            return Ok(products);
        }

        [HttpGet("subcategory/{subCategoryId}/products")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProductForCategoryWithSubCategory([FromRoute] int categoryId, 
            [FromRoute] int subCategoryId)
        {
            var products = await mediator.Send(new GetAllProductsForCategoryWithSubCategoryQuery(categoryId, subCategoryId));
            return Ok(products);
        }

        [HttpGet("subcategory/{subCategoryId}/brand/{brandId}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProductForCategoryWithSubCategoryAndBrand([FromRoute] int categoryId,
            [FromRoute] int subCategoryId, [FromRoute] int brandId)
        {
            var products = await mediator.Send(new GetAllProductForCategoryWithSubCategoryAndBrandQuery(categoryId, subCategoryId, brandId));
            return Ok(products);
        }
    }
}
