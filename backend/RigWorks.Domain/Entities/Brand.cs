namespace RigWorks.Domain.Entities;

public sealed class Brand
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public ICollection<Component> Components { get; set; } = new List<Component>();
}
