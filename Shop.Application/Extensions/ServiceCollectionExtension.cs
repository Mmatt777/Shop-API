using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Categories;
using Shop.Application.SubCategories;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;


namespace Shop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var appAssembly = typeof(ServiceCollectionExtension).Assembly;

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(appAssembly));
           
            services.AddAutoMapper(appAssembly);

            services.AddValidatorsFromAssembly(appAssembly)
                .AddFluentValidationAutoValidation();
               
        }
    }
}
