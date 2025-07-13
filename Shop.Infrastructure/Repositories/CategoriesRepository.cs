using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Persistens;


namespace Shop.Infrastructure.Repositories
{
    internal class CategoriesRepository(ShopDbContext dbContext) : ICategoriesRepository
    {
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await dbContext.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategoryByIdWithsubCategoryAsync(int id)
        {
            var category = await dbContext.Categories
                .Include(c => c.SubCategories)
                .FirstOrDefaultAsync(c => c.Id == id);

            return category;

        }

        public async Task<Category> GetCategoryByIdWithBrandsAsync(int id)
        {
            var category = await dbContext.Categories
                .Include(c => c.Brands)
                .FirstOrDefaultAsync(c => c.Id == id);

            return category;
        }
        
        public async Task<Category> GetCategoryByIdWithSubCategoryIdWithBrands(int id)
        {
            var category = await dbContext.Categories
                    .Include(c => c.SubCategories)
                    .Include(sc => sc.Brands)
                    .FirstOrDefaultAsync(c => c.Id == id);

            return category;

        }
        
    }
}
