using MediatR;
using Shop.Application.Products.DTOS;


namespace Shop.Application.Products.Queries.GetAllProductsForCategoryWithSubCategory
{
    public record class GetAllProductsForCategoryWithSubCategoryQuery(int categoryId, int subCategoryId) 
        : IRequest<IEnumerable<ProductDTO>>
    {
    }
}
