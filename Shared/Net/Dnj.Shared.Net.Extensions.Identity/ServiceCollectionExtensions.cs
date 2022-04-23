using Dnj.Shared.Net.Extensions.Identity.Data;
using Dnj.Shared.Net.Extensions.Identity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDnjIdentitySqLite(this IServiceCollection services, string connectionString)
        {
            services.AddDnjIdentitySqLite(connectionString, options => {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 0;
                options.Password.RequiredUniqueChars = 0;

                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            return services;
        }

        public static IServiceCollection AddDnjIdentitySqLite(this IServiceCollection services, string connectionString, Action<IdentityOptions> identityOptions)
        {
            services.AddDbContext<DnjIdentityDbContext>(storeOptions =>
                    storeOptions.UseSqlite(connectionString));

            var currentServices = services.BuildServiceProvider();
            currentServices.GetRequiredService<DnjIdentityDbContext>().Database.EnsureCreated();

            services.AddDefaultIdentity<DnjApplicationUser>(identityOptions)
                .AddEntityFrameworkStores<DnjIdentityDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<DnjApplicationUser, DnjIdentityDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();
            return services;
        }


    }
}
