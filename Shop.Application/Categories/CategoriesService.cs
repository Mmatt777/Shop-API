﻿using Microsoft.Extensions.Logging;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;

namespace Shop.Application.Categories
{
    internal class CategoriesService(ICategoriesRepository categoriesRepository,
        ILogger<CategoriesService> logger) : ICategoriesService
    {
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            logger.LogInformation("Getting all categories");
            var categories = await categoriesRepository.GetAllAsync();
            return categories;
        }
    }
}
