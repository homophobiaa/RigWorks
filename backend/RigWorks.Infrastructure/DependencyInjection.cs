using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RigWorks.Infrastructure.Data;
using RigWorks.Infrastructure.Identity;

namespace RigWorks.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        // Defer resolution: builds, liveness and OpenAPI need no database credentials.
        services.AddDbContext<RigWorksDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("RigWorks")
                ?? throw new InvalidOperationException(
                    "Set ConnectionStrings:RigWorks with .NET user-secrets. See docs/development.md.");
            options.UseSqlServer(connectionString, sql => sql.EnableRetryOnFailure());
        });

        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Lockout.AllowedForNewUsers = true;
        })
            .AddEntityFrameworkStores<RigWorksDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}
