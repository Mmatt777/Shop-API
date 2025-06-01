using Microsoft.Extensions.Logging;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;

namespace Shop.Application.Categories
{
    internal class CategoriesService(ICategoriesRepository categoriesRepository,
        ILogger<CategoriesService> logger) : ICategoriesService
    {
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            logger.LogInformation("Getting all categories");
            var categories = await categoriesRepository.GetAllAsync();
            return categories;
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            logger.LogInformation($"Getting category by {id}");
            var category = await categoriesRepository.GetCategoryByIdAsync(id);
            return category;
        }
    }
}
