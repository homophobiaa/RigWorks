using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RigWorks.Domain.Entities;

namespace RigWorks.Infrastructure.Data.Configurations;

public sealed class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands", table =>
            table.HasCheckConstraint("CK_Brands_Name_NotBlank", "LEN(LTRIM(RTRIM([Name]))) > 0"));
        builder.HasKey(brand => brand.Id);
        builder.Property(brand => brand.Id).UseIdentityColumn();
        builder.Property(brand => brand.Name).HasMaxLength(100).IsRequired();
        builder.HasIndex(brand => brand.Name).IsUnique();
    }
}
