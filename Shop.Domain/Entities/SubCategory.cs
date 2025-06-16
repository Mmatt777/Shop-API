
namespace Shop.Domain.Entities
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Product> Products { get; set; } = new();
        public List<Brand> Brands { get; set; } = new();

    }
}
