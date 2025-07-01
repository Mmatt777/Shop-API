using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SubCategories.Commands.DeleteSubCategory
{
    public record class DeleteSubCategoryForCategoryCommand(int categoryId, int subCategoryId) : IRequest
    {
    }
}
