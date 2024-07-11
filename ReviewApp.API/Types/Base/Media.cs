using HotChocolate.Authorization;
using ReviewApp.API.Interfaces;
using ReviewApp.API.Types.Enums;

namespace ReviewApp.API.Types.Base;

[Authorize]
public class Media : ICreatable, IModifiable
{
    public Guid Id { get; set; }
    public required MediaType MediaType { get; set; }
    public required Genre Genre { get; set; }
    public required string Name { get; set; }
    public string? CoverImageUrl { get; set; }
    public string? Description { get; set; }
    public required Guid StudioId { get; set; }

    // TODO: This changes to DateEstablished
    public required DateOnly DateFounded { get; set; }

    [GraphQLIgnore]
    public Studio? Studio { get; set; }

    public required DateTime CreatedAt { get; set; }
    public required string CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }
    public string? ModifiedBy { get; set; }

    // public async Task<Studio?> GetStudio(StudioByIdDataLoader dataLoader)
    // {
    //     return await dataLoader.LoadAsync(StudioId);
    // }
}
