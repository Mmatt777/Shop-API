using Shop.Application.Products.DTOS;


namespace Shop.Application.Brands.DTOS
{
    public class BrandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductDTO> Products { get; set; } = new();
    }
}
