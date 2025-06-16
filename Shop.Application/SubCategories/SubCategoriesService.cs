using AutoMapper;
using Microsoft.Extensions.Logging;
using Shop.Application.SubCategories.DTOS;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;

namespace Shop.Application.SubCategories
{
    public class SubCategoriesService(ISubCategoriesRepository subCategoriesRepository,
        ILogger<SubCategoriesService> logger,
        IMapper mapper) : ISubCategoriesService
    {
        public async Task<int> CreateSubCategory(CreateSubCategoryDTO dto)
        {
            logger.LogInformation("Creating a new SubCategory");

            var subCategory = mapper.Map<SubCategory>(dto);

            var subCategoryCreated = await subCategoriesRepository.CreateSubCategory(subCategory);
            return subCategoryCreated;
        }

    }
}
