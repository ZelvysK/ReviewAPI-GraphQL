using Microsoft.EntityFrameworkCore;
using ReviewApp.API.Types.DataLoaders;
using ReviewApp.API.Types.Enums;

namespace ReviewApp.API.Types;

public class Media
{
    public Guid Id { get; set; }
    public MediaType MediaType { get; set; }
    public Genre Genre { get; set; }
    public string Name { get; set; }
    public string CoverImageUrl { get; set; }
    public string Description { get; set; }
    public Guid StudioId { get; set; }

    [GraphQLIgnore]
    public Studio? Studio { get; set; }

    public string PublishedBy { get; set; }
    public DateTime DatePosted { get; set; }
    public DateTime DateModified { get; set; }
    public DateOnly DateCreated { get; set; }

    public async Task<Studio?> GetStudio(StudioByIdDataLoader dataLoader)
    {
        return await dataLoader.LoadAsync(StudioId);
    }
}
