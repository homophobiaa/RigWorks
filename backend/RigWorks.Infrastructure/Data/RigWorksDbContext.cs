using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RigWorks.Infrastructure.Identity;

namespace RigWorks.Infrastructure.Data;

public sealed class RigWorksDbContext(DbContextOptions<RigWorksDbContext> options)
    : IdentityDbContext<ApplicationUser>(options);
