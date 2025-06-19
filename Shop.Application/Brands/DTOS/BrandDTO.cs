using Shop.Application.Products.DTOS;
using Shop.Domain.Entities;


namespace Shop.Application.Brands.DTOS
{
    public class BrandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductDTO> Products { get; set; } = new();

        //public static BrandDTO FromEntity(Brand brand)
        //{
        //    return new BrandDTO()
        //    {
        //        Id = brand.Id,
        //        Name = brand.Name
        //    };
        //}
    }
}
