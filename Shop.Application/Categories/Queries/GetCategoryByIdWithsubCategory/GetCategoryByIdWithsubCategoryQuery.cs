using MediatR;
using Shop.Application.Categories.DTOS;

namespace Shop.Application.Categories.Queries.GetCategoryByIdWithsubCategory
{
    public record class GetCategoryByIdWithsubCategoryQuery(int Id) : IRequest<CategoryDTO>
    {
    }
}
