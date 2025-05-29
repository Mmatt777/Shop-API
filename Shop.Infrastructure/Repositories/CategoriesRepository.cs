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
    }
}
