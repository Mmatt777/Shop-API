using Shop.Domain.Entities;

namespace Shop.Domain.Repositories
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetCategoryByIdWithsubCategoryAsync(int id);
    }
}
