using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products.Commands.CreateProduct;
using Shop.Application.Products.DTOS;
using Shop.Application.Products.Queries.GetAllProductForCategoryQuery;
using Shop.Application.Products.Queries.GetAllProductForCategoryWithSubCategoryAndBrand;
using Shop.Application.Products.Queries.GetAllProductsForCategoryWithSubCategory;
using Shop.Domain.Constants;
using Shop.Domain.Entities;

namespace Shop.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/category/{categoryId}/")]
    public class ProductsController(IMediator mediator) : ControllerBase
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
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProductsForCategoryWithSubCategory([FromRoute] int categoryId, 
            [FromRoute] int subCategoryId)
        {
            var products = await mediator.Send(new GetAllProductsForCategoryWithSubCategoryQuery(categoryId, subCategoryId));
            return Ok(products);
        }

        [HttpGet("subcategory/{subCategoryId}/brand/{brandId}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProductsForCategoryWithSubCategoryAndBrand([FromRoute] int categoryId,
            [FromRoute] int subCategoryId, [FromRoute] int brandId)
        {
            var products = await mediator.Send(new GetAllProductForCategoryWithSubCategoryAndBrandQuery(categoryId, subCategoryId, brandId));
            return Ok(products);
        }

        [HttpPost("subcategory/{subCategoryId}/brand/{brandId}")]
        [Authorize(Roles = IdentityRoles.Admin)]
        public async Task<IActionResult> CreateProduct([FromRoute] int categoryId,
            [FromRoute]int subCategoryId,
            [FromRoute]int brandId,
            CreateProductForCategoryIdAndSubcateoryIdWithBrandIdCommand command 
            )
        {
            command.CategoryId = categoryId;
            command.SubCategoryId = subCategoryId;
            command.BrandId = brandId;
            var product = await mediator.Send(command);
            return Ok();
        }
    }
}
