using Shop.Domain.Entities;


namespace Shop.Domain.Repositories
{
    public interface ISubCategoriesRepository
    {
        Task<int> CreateSubCategory(SubCategory subCategory);
        Task Delete(SubCategory subCategory);
        Task SaveUpdate();
    }
}
