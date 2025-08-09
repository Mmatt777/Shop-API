using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Persistens;


namespace Shop.Infrastructure.Repositories
{
    internal class SubCategoryRepository(ShopDbContext dbContext) : ISubCategoriesRepository
    {
        public async Task<int> CreateSubCategory(SubCategory subCategory)
        {
            dbContext.SubCategories.Add(subCategory);
            await dbContext.SaveChangesAsync();
            return subCategory.Id;
        }

        public async Task Delete(SubCategory subCategory)
        {
            dbContext.Remove(subCategory);
            await dbContext.SaveChangesAsync();
        }
        public async Task SaveUpdate() => await dbContext.SaveChangesAsync();
    }
}
