using Microsoft.Extensions.Logging;
using Shop.Application.Categories.DTOS;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;

namespace Shop.Application.Categories
{
    internal class CategoriesService(ICategoriesRepository categoriesRepository,
        ILogger<CategoriesService> logger) : ICategoriesService
    {
        public async Task<IEnumerable<CategoryDTO>> GetAllCategory()
        {
            logger.LogInformation("Getting all categories");
            var categories = await categoriesRepository.GetAllAsync();

            var categoryDTO = categories.Select(CategoryDTO.FromEntity);

            return categoryDTO!;
        }

        public async Task<CategoryDTO?> GetCategoryById(int id)
        {
            logger.LogInformation($"Getting category by {id}");
            var category = await categoriesRepository.GetCategoryByIdAsync(id);
            var categoryDTO = CategoryDTO.FromEntity(category);


            return categoryDTO;
        }
    }
}
