using MediatR;
using Shop.Application.Brands.DTOS;


namespace Shop.Application.Brands.Queries.GetAllBrandsForSubcategoryWithCategory
{
    public record class GetAllBrandsForSubcategoryWithCategoryQuery(int categoryId, int subcategoryId) 
        : IRequest<IEnumerable<BrandDTO>>
    {
    }
}
