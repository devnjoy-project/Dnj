using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Localization;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDnjSqLite<T>(this IServiceCollection services, string connectionString) where T : DbContext
        {
            services.AddDbContext<T>(storeOptions =>
            {
                storeOptions.UseSqlite(connectionString);
                storeOptions.EnableSensitiveDataLogging(true);
            });
            
            return services;
        }

    }

    
}