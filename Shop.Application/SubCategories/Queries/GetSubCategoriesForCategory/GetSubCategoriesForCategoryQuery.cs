using MediatR;
using Shop.Application.SubCategories.DTOS;

namespace Shop.Application.SubCategories.Queries.GetSubCategoryById
{
    public record class GetSubCategoriesForCategoryQuery(int CategoryId) : IRequest<IEnumerable<SubCategoryDTO>>
    {
        public int CategoryId { get;} = CategoryId;
    }
}
