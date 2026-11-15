using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RigWorks.Domain.Entities;
using RigWorks.Infrastructure.Identity;

namespace RigWorks.Infrastructure.Data.Configurations;

public sealed class PcBuildConfiguration : IEntityTypeConfiguration<PcBuild>
{
    public void Configure(EntityTypeBuilder<PcBuild> builder)
    {
        builder.ToTable("PcBuilds", table =>
        {
            table.HasCheckConstraint("CK_PcBuilds_Name_NotBlank", "LEN(LTRIM(RTRIM([Name]))) > 0");
            table.HasCheckConstraint("CK_PcBuilds_Budget_NonNegative", "[Budget] IS NULL OR [Budget] >= 0");
        });
        builder.HasKey(build => build.Id);
        builder.Property(build => build.Id).UseIdentityColumn();
        builder.Property(build => build.Name).HasMaxLength(100).IsRequired();
        builder.Property(build => build.UserId).HasMaxLength(450).IsRequired();
        builder.Property(build => build.Budget).HasPrecision(18, 2);

        // The Identity relationship belongs here so Domain needs no Identity reference.
        builder.HasOne<ApplicationUser>()
            .WithMany(user => user.Builds)
            .HasForeignKey(build => build.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
