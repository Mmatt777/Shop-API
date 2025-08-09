using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Application.SubCategories.DTOS;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;


namespace Shop.Application.SubCategories.Queries.GetSubCategoryById
{
    public class GetSubCategoriesForCategoryQueryHandler(ILogger<GetSubCategoriesForCategoryQuery> logger,
        ICategoriesRepository categoriesRepository, 
        IMapper mapper) 
        : IRequestHandler<GetSubCategoriesForCategoryQuery, IEnumerable<SubCategoryDTO>>
    {
        public async Task<IEnumerable<SubCategoryDTO>> Handle(GetSubCategoriesForCategoryQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Geting subcategory for category with id {CategoryId}", request.CategoryId);

            var category = await categoriesRepository.GetCategoryByIdWithsubCategoryAsync(request.CategoryId);
            if (category == null) throw new NotFoundException(nameof(Category), request.CategoryId.ToString());

            var subCategories = mapper.Map<IEnumerable<SubCategoryDTO>>(category.SubCategories);

            // var subCategories = SubCategoryDTO.FromEntity(subCategoryById); // Manual mapping is used here
            return subCategories;
        }
    }
}
