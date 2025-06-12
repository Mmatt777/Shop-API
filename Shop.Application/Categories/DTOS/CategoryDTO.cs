using Shop.Application.Brands.DTOS;
using Shop.Application.Products.DTOS;
using Shop.Application.SubCategories.DTOS;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.DTOS
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductDTO> Products { get; set; } = new();
        public List<BrandDTO> Brands { get; set; } = new();
        public List<SubCategoryDTO> SubCategories { get; set; } = [];

        public static CategoryDTO? FromEntity(Category category)
        {
            if(category == null) return null;
            return new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
                SubCategories = category.SubCategories.Select(SubCategoryDTO.FromEntity).ToList()
            };
        }
    }
}
