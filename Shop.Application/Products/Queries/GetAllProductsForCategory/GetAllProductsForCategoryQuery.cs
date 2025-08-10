using MediatR;
using Shop.Application.Products.DTOS;


namespace Shop.Application.Products.Queries.GetAllProductForCategoryQuery
{
    public record class GetAllProductsForCategoryQuery(int categoryId) : IRequest<IEnumerable<ProductDTO>>
    {
    }
}
