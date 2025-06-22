using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;

namespace Shop.Application.SubCategories.Commands.CreateSubCategory
{
    public class CreateSubCategoryCommnadHandler(ILogger<CreateSubCategoryCommnadHandler> logger,
        IMapper mapper, ISubCategoriesRepository subCategoriesRepository) 
        : IRequestHandler<CreateSubCategoryCommnad, int>
    {
        public async Task<int> Handle(CreateSubCategoryCommnad request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a new SubCategory");

            var subCategory = mapper.Map<SubCategory>(request);
            // var subCategory = CreateSubCategoryDTO.FromDTO(request); // Manual mapping is used here

            var subCategoryCreated = await subCategoriesRepository.CreateSubCategory(subCategory);
            return subCategoryCreated;
        }
    }
}
