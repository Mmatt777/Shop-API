using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Persistens;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<SubCategory> GetSubCategoryByIdAsync(int id)
        {
            var subCategory = await dbContext.SubCategories
                .Include(c => c.Products)
                .Include(c => c.Brands)
                .FirstOrDefaultAsync(c => c.Id == id);

            return subCategory!;
        }

        public async Task SaveUpdate() => await dbContext.SaveChangesAsync();
    }
}
