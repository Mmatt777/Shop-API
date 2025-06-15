using AutoMapper;
using Microsoft.Extensions.Logging;
using Shop.Application.Categories.DTOS;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;

namespace Shop.Application.Categories
{
    internal class CategoriesService(ICategoriesRepository categoriesRepository,
        ILogger<CategoriesService> logger,
        IMapper mapper) : ICategoriesService
    {
        public async Task<IEnumerable<CategoryDTO>> GetAllCategory()
        {
            logger.LogInformation("Getting all categories");
            var categories = await categoriesRepository.GetAllAsync();

            var categoryDTO = mapper.Map<IEnumerable<CategoryDTO>>(categories); // Automapper is used here  

            //var categoryDTO = categories.Select(CategoryDTO.FromEntity); // Manual mapping is used here

            return categoryDTO!;
        }

        public async Task<CategoryDTO?> GetCategoryByIdWithsubCategory(int id)
        {
            logger.LogInformation($"Getting category by {id}");
            var category = await categoriesRepository.GetCategoryByIdWithsubCategoryAsync(id);

            var categoryDTO = mapper.Map<CategoryDTO?>(category);

            //var categoryDTO = CategoryDTO.FromEntity(category); Manual mapping is used here


            return categoryDTO;
        }
    }
}
