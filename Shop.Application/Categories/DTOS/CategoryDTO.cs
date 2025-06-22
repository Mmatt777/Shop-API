using Shop.Application.Brands.DTOS;
using Shop.Application.Products.DTOS;
using Shop.Application.SubCategories.DTOS;

namespace Shop.Application.Categories.DTOS
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductDTO> Products { get; set; } = new();
        public List<BrandDTO> Brands { get; set; } = new();
        public List<SubCategoryDTO> SubCategories { get; set; } = [];

        //Manual maipping
        //public static CategoryDTO? FromEntity(Category category)
        //{
        //    if(category == null) return null;
        //    return new CategoryDTO()
        //    {
        //        Id = category.Id,
        //        Name = category.Name,
        //        SubCategories = category.SubCategories.Select(SubCategoryDTO.FromEntity).ToList()
        //    };
        //}
    }
}
