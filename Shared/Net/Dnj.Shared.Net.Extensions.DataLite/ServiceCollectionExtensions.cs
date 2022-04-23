using Microsoft.EntityFrameworkCore;

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