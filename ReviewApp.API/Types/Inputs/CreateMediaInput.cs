using ReviewApp.API.Types.Enums;

namespace ReviewApp.API.Types.Inputs;

public class CreateMediaInput
{
    public required MediaType MediaType { get; set; }
    public required Genre Genre { get; set; }
    public required string Name { get; set; }
    public required string CoverImageUrl { get; set; }
    public required string Description { get; set; }
    public required Guid StudioId { get; set; }
    public required string PublishedBy { get; set; }
    public required DateOnly DateFounded { get; set; }
}