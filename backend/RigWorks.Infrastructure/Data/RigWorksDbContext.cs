using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RigWorks.Domain.Entities;
using RigWorks.Infrastructure.Identity;

namespace RigWorks.Infrastructure.Data;

public sealed class RigWorksDbContext(DbContextOptions<RigWorksDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Component> Components => Set<Component>();
    public DbSet<PcBuild> PcBuilds => Set<PcBuild>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(RigWorksDbContext).Assembly);
    }
}
