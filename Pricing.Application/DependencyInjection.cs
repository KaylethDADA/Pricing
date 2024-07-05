using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Pricing.Application.Services;
using System.Reflection;

namespace Pricing.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            return services;
        }
        public static IServiceCollection AddServiceApplication(this IServiceCollection services)
        {
            services.AddScoped<ProductCategoryService>();
            services.AddScoped<CityService>();
            services.AddScoped<ProductService>();
            services.AddScoped<ShopService>();
            services.AddScoped<UserService>();
            services.AddScoped<AuthService>();

            return services;
        }
    }
}
