using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Application.Brands.DTOS;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;

namespace Shop.Application.Brands.Queries.GetAllBrandsForSubcategoryWithCategory
{
    public class GetAllBrandsForSubcategoryWithCategoryQueryHandler(ILogger<GetAllBrandsForSubcategoryWithCategoryQuery> logger,
        IBrandsRepository brandsRepository,
        IMapper mapper)
        : IRequestHandler<GetAllBrandsForSubcategoryWithCategoryQuery, IEnumerable<BrandDTO>>
    {
        public async Task<IEnumerable<BrandDTO>> Handle(GetAllBrandsForSubcategoryWithCategoryQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Get all brands for category: {cateogryId}, with {@subcategoryId}", request.categoryId, request.subcategoryId);

            var category = await brandsRepository.GetCategoryByIdWithSubCategoryIdWithBrands(request.categoryId);
            if(category == null) 
                throw new NotFoundException(nameof(Category), request.categoryId.ToString());

            var subcategory = category.SubCategories.FirstOrDefault(s => s.Id == request.subcategoryId);
            if(subcategory == null) 
                throw new NotFoundException(nameof(SubCategory), request.subcategoryId.ToString());
            var brands = subcategory.Brands.ToList();

            var result = mapper.Map<IEnumerable<BrandDTO>>(brands);

            return result;

        }
    }
}
