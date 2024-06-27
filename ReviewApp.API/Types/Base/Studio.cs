using HotChocolate.Authorization;
using ReviewApp.API.Interfaces;
using ReviewApp.API.Types.Enums;

namespace ReviewApp.API.Types.Base;

[Authorize]
public class Studio : ICreatable, IModifiable
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public required string Founder { get; set; }
    public required string Headquarters { get; set; }

    public required StudioType StudioType { get; set; }
    public required DateOnly DateEstablished { get; set; }

    public required DateTime CreatedAt { get; set; }
    public required string CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }
    public string? ModifiedBy { get; set; }
}
