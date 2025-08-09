using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Persistens;

namespace Shop.Infrastructure.Repositories
{
    public class ProductsRepository(ShopDbContext dbContext) : IProductsRepository
    {
        public async Task<Category> GetAllProductsForCategory(int id)
        {
            var products = await dbContext.Categories
               .Include(p => p.Products)
               .FirstOrDefaultAsync(p => p.Id == id);

            return products;
        }

        public async Task<Category> GetAllProductsForCategoryWithSubCategory(int Id)
        {
            var products = await dbContext.Categories
                .Include(c => c.SubCategories)
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == Id);

            return products;
        }
    }
}
