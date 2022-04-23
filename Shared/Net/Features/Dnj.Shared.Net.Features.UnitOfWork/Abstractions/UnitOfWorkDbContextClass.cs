using Dnj.Shared.Net.Features.UnitOfWork.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dnj.Shared.Net.Features.UnitOfWork.Abstractions
{
    public abstract class UnitOfWorkDbContextClass : DbContext
    {
        public UnitOfWorkDbContextClass(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<UnitOfWorkEntity> UnitOfWorkSet { get; set; } 
    }
}
