using Shop.Application.Brands.DTOS;
using Shop.Application.Products.DTOS;
using Shop.Domain.Entities;

namespace Shop.Application.SubCategories.DTOS
{
    public class SubCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductDTO> Products { get; set; } = new();
        public List<BrandDTO> Brands { get; set; } = new();

        // Manual mapping
        //public static SubCategoryDTO FromEntity(SubCategory  subCategory)
        //{
        //    return new SubCategoryDTO()
        //    {
        //        Id = subCategory.Id,
        //        Name = subCategory.Name,
        //    };
        //}
    }
}
