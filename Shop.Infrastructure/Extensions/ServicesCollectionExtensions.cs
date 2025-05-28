using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure.Persistens;
using System.Runtime.CompilerServices;

namespace Shop.Infrastructure.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("ShopDb");
            services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
