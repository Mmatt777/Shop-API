using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.Extensions.Logging;
using Shop.Application.SubCategories.DTOS;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;

namespace Shop.Application.SubCategories.Queries.GetAllSubcategoriesByIdForCategory
{
    public class GetSubcategoryByIdForCategoryQueryHandler(ILogger<GetSubcategoryByIdForCategoryQueryHandler> logger, 
        ICategoriesRepository categoriesRepository, 
        IMapper mapper)
        : IRequestHandler<GetSubcategoryByIdForCategoryQuery, SubCategoryDTO>
    {
        public async Task<SubCategoryDTO> Handle(GetSubcategoryByIdForCategoryQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Get subcateogry by id {subCategoryId} with id of category {CategoryId}", 
                request.subCategoryId, request.categoryId);

            var category = await categoriesRepository.GetCategoryByIdWithsubCategoryAsync(request.categoryId);
            if (category == null) throw new NotFoundException(nameof(Category), request.categoryId.ToString());

            var subcategory = category.SubCategories.FirstOrDefault(s => s.Id == request.subCategoryId);
            if (category == null) throw new NotFoundException(nameof(SubCategory), request.subCategoryId.ToString());


            var result = mapper.Map<SubCategoryDTO>(subcategory);

            return result;
        }
    }
}
