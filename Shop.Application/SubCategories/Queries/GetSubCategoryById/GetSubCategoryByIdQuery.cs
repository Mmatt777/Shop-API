using MediatR;
using Shop.Application.SubCategories.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SubCategories.Queries.GetSubCategoryById
{
    public record class GetSubCategoryByIdQuery(int Id) : IRequest<SubCategoryDTO?>
    {
    }
}
