using Shop.Application.Categories.DTOS;


namespace Shop.Application.Categories
{
    public interface ICategoriesService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategory();
        Task<CategoryDTO> GetCategoryById(int id);
    }
}