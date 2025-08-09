using MediatR;
using Shop.Application.SubCategories.DTOS;


namespace Shop.Application.SubCategories.Queries.GetAllSubcategoriesByIdForCategory
{
    public record class GetSubcategoryByIdForCategoryQuery(int categoryId, int subCategoryId) : IRequest<SubCategoryDTO>
    {
    }
}
