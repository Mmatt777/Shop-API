using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.DTOS
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public string Description { get; set; }

        // Manual mapping
        //public static ProductDTO FromEntity(Product product)
        //{
        //    return new ProductDTO()
        //    {
        //        Id = product.Id,
        //        Name = product.Name,
        //        Cost = product.Cost,
        //        Description = product.Description
        //    };
        //}

    }
}
