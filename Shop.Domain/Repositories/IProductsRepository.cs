using Shop.Domain.Entities;

namespace Shop.Domain.Repositories
{
    public interface IProductsRepository
    {
        Task<Category> GetAllProductsForCategory(int id);
        Task<Category> GetProductByIdForCategory(int Id);
        Task<Category> GetAllProductsForCategoryWithSubCategory(int Id);
        Task<Category> GetAllProductForCategoryWithSubCategoryAndBrand(int Id);
        Task<Guid> CreateProduct(Product product);
        Task DeleteProduct(Product product);
    }
}
