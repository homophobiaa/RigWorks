using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RigWorks.Domain.Entities;

namespace RigWorks.Infrastructure.Data.Configurations;

public sealed class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.ToTable("Components", table =>
        {
            table.HasCheckConstraint("CK_Components_Name_NotBlank", "LEN(LTRIM(RTRIM([Name]))) > 0");
            table.HasCheckConstraint("CK_Components_Price_NonNegative", "[Price] IS NULL OR [Price] >= 0");
            table.HasCheckConstraint("CK_Components_Category", "[Category] IN ('Cpu', 'Gpu', 'Motherboard', 'Memory', 'Storage', 'PowerSupply', 'Case', 'Cooling')");
        });
        builder.HasKey(component => component.Id);
        builder.Property(component => component.Id).UseIdentityColumn();
        builder.Property(component => component.Name).HasMaxLength(200).IsRequired();
        builder.Property(component => component.BrandId).IsRequired();
        builder.Property(component => component.Category)
            .HasConversion<string>().HasMaxLength(32).IsUnicode(false).IsRequired();
        builder.Property(component => component.Price).HasPrecision(18, 2);
        builder.HasOne(component => component.Brand)
            .WithMany(brand => brand.Components)
            .HasForeignKey(component => component.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(component => component.Category);
    }
}
