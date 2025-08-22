using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Commands.DeleteProduct
{
    public record class DeleteProductForCategoryCommand(int categoryId, Guid productId) : IRequest
    {
    }
}
