using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Shop.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }


        public int BrandId { get; set; }
        public Brand Brand { get; set; }

    }
}
