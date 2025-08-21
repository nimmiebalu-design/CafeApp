using CafeApp.Core.Interfaces;
using CafeApp.Infrastructure.Data;
using CafeApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CafeApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            // Register infrastructure services here
            // Example: services.AddTransient<IInfrastructureService, InfrastructureService>();            
            return services;
        }   
    } 
}
