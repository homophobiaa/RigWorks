namespace RigWorks.Domain.Entities;

public sealed class PcBuild
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string UserId { get; set; }

    /// <summary>Optional spending limit in EUR.</summary>
    public decimal? Budget { get; set; }
}
