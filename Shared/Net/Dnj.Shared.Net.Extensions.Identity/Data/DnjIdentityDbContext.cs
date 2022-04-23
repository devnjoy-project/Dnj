using Dnj.Shared.Net.Extensions.Identity.Models;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Dnj.Shared.Net.Extensions.Identity.Data
{
    public class DnjIdentityDbContext : ApiAuthorizationDbContext<DnjApplicationUser>
    {
        public DnjIdentityDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}