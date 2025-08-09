using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Persistens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories
{
    public class BrandsRepository(ShopDbContext dbContext) : IBrandsRepository
    {
        public async Task<IEnumerable<Brand>> GetAllBrandsAsync()
        {
            var brands = await dbContext.Brands.ToListAsync();
            return brands;
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
