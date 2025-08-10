using MediatR;
using Shop.Application.Products.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Queries.GetAllProductForCategoryWithSubCategoryAndBrand
{
    public record class GetAllProductForCategoryWithSubCategoryAndBrandQuery(int categoryId, int subCategoryId, int brandId)
        :IRequest<IEnumerable<ProductDTO>>
    {
    }
}
