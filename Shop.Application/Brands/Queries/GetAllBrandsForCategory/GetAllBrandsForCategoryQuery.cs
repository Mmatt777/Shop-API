using MediatR;
using Shop.Application.Brands.DTOS;

namespace Shop.Application.Brands.Queries.GetAllBrandsForCategory
{
    public record class GetAllBrandsForCategoryQuery(int categoryId) : IRequest<IEnumerable<BrandDTO>>
    {
    }
}
