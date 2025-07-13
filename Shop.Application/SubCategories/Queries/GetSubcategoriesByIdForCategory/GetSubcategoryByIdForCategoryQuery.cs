using MediatR;
using Shop.Application.SubCategories.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SubCategories.Queries.GetAllSubcategoriesByIdForCategory
{
    public record class GetSubcategoryByIdForCategoryQuery(int categoryId, int subCategoryId) : IRequest<SubCategoryDTO>
    {
    }
}
