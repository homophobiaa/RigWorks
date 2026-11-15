using RigWorks.Domain.Enums;

namespace RigWorks.Domain.Entities;

public sealed class Component
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int BrandId { get; set; }
    public ComponentCategory Category { get; set; }

    /// <summary>Entered price in EUR; null means unknown, not free.</summary>
    public decimal? Price { get; set; }

    public Brand Brand { get; set; } = null!;
}
