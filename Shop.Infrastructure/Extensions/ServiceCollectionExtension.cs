using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Authorization;
using Shop.Infrastructure.Authorization.Requirements;
using Shop.Infrastructure.Authorization.Services;
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
                .AddRoles<IdentityRole>()
                .AddClaimsPrincipalFactory<ShopUserClaimsPrincipalFactory>()
                .AddEntityFrameworkStores<ShopDbContext>();

            services.AddScoped<IShopSeeder, ShopSeeder>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ISubCategoriesRepository, SubCategoryRepository>();
            services.AddAuthorizationBuilder()
                .AddPolicy(PolitycyNames.HasCountry, builder => builder.RequireClaim(AppClaimTypes.Country))
                .AddPolicy(PolitycyNames.Over18YearsOld, builder => builder.AddRequirements(new MinimumAgeRequirement(18)));

            services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
            services.AddScoped<IShopAuthorizationService, ShopAuthorizationService>();
                
        }
    }
}
