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
            // var subCategory = CreateSubCategoryDTO.FromDTO(dto); // Manual mapping is used here

            var subCategoryCreated = await subCategoriesRepository.CreateSubCategory(subCategory);
            return subCategoryCreated;
        }

        public async Task<SubCategoryDTO> GetSubCategoryById(int id)
        {
            logger.LogInformation("Geting subcategory by id");
            var subCategoryById = await subCategoriesRepository.GetSubCategoryById(id);

            var subCategoryDTO = mapper.Map<SubCategoryDTO>(subCategoryById);
            // var subCategoryDTO = SubCategoryDTO.FromEntity(subCategoryById); // Manual mapping is used here
            return subCategoryDTO;
        }
    }
}
