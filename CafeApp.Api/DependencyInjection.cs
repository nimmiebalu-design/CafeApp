using CafeApp.Application;
using CafeApp.Core;
using CafeApp.Infrastructure;

namespace CafeApp.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            // Register core services here
            // Example: services.AddTransient<ICoreService, CoreService>();
            services.AddApplicationDI();
            services.AddInfrastructureDI();
            services.AddCoreDI();
            return services;
        }
    }
}
