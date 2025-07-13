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
             
    }
}
