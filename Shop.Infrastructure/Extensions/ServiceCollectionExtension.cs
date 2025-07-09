using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Persistens;
using Shop.Infrastructure.Repositories;
using Shop.Infrastructure.Seeders;

namespace Shop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var conString = configuration.GetConnectionString("ShopDb");
            services.AddDbContext<ShopDbContext>(options => options
            .UseSqlServer(conString)
            .EnableSensitiveDataLogging());

            services.AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<ShopDbContext>();

            services.AddScoped<IShopSeeder, ShopSeeder>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ISubCategoriesRepository, SubCategoryRepository>();
        }
    }
}
