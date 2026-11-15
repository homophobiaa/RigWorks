using Microsoft.AspNetCore.Identity;
using RigWorks.Domain.Entities;

namespace RigWorks.Infrastructure.Identity;

public sealed class ApplicationUser : IdentityUser
{
    public ICollection<PcBuild> Builds { get; set; } = new List<PcBuild>();
}
