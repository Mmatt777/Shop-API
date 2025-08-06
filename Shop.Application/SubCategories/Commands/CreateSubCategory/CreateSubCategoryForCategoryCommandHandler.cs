using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Authorization.Services;
using Shop.Infrastructure.Authorization;

namespace Shop.Application.SubCategories.Commands.CreateSubCategory
{
    public class CreateSubCategoryForCategoryCommandHandler(ILogger<CreateSubCategoryForCategoryCommandHandler> logger,
        IMapper mapper, ICategoriesRepository categoriesRepository, 
        ISubCategoriesRepository subCategoriesRepository,
        IShopAuthorizationService shopAuthorizationService) 
        : IRequestHandler<CreateSubCategoryForCategoryCommand, int>
    {
        public async Task<int> Handle(CreateSubCategoryForCategoryCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a new subcategory {@SubCategory}", request);
            var category = await categoriesRepository.GetCategoryByIdWithsubCategoryAsync(request.CategoryId);
            if (category == null) 
                throw new NotFoundException(nameof(Category), request.CategoryId.ToString());


            if (!shopAuthorizationService.IsAuthorize(ResourceOperation.Create))
                throw new ForbidException();

            var subCategory = mapper.Map<SubCategory>(request);
            // var subCategory = CreateSubCategoryDTO.FromDTO(request); // Manual mapping is used here

           return await subCategoriesRepository.CreateSubCategory(subCategory);
        }
    }
}
