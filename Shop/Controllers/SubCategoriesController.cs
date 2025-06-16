using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.SubCategories;
using Shop.Application.SubCategories.DTOS;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("SubCategories")]
    public class SubCategoriesController(ISubCategoriesService subCategoriesService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateSubCategories([FromBody] CreateSubCategoryDTO createSubCategoryDTO)
        {
            var subCategory = await subCategoriesService.CreateSubCategory(createSubCategoryDTO);

            return Ok(subCategory);
        }
    }
}
