using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Commands.CreateProduct
{
    public class CreateProductForCategoryIdAndSubcateoryIdWithBrandIdCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public float Cost { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }


        public int SubCategoryId { get; set; }


        public int BrandId { get; set; }
    }
}
