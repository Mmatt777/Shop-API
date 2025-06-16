using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Categories;
using Shop.Application.SubCategories;


namespace Shop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<ISubCategoriesService, SubCategoriesService>();

            services.AddAutoMapper(typeof (ServiceCollectionExtension).Assembly);
        }
    }
}
