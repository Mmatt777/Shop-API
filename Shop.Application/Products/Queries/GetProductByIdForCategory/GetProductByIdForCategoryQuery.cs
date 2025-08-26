using MediatR;
using Shop.Application.Products.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Queries.GetProductByIdForCategory
{
    public record class GetProductByIdForCategoryQuery(int categoryId, Guid productId) : IRequest<ProductDTO>
    {
    }
}
