using Dnj.Shared.Net.Data.Abstractions;
using Dnj.Shared.Net.Features.UnitOfWork;
using Dnj.Shared.Net.Features.UnitOfWork.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Dnj.Samples.UnitOfWork.Server.Data
{
    public class UnitOfWorkContext : UnitOfWorkDbContextClass
    {
        public UnitOfWorkContext(DbContextOptions<UnitOfWorkContext> options):base(options)
        {
        }
    }
}
