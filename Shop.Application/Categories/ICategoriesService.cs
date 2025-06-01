using Shop.Domain.Entities;

namespace Shop.Application.Categories
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category> GetCategoryById(int id);
    }
}