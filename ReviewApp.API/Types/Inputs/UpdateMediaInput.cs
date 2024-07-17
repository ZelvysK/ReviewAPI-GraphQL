using ReviewApp.API.Types.Enums;

namespace ReviewApp.API.Types.Inputs;

public class UpdateMediaInput
{
    public required Guid Id { get; set; }
    public required MediaType MediaType { get; set; }
    public required Genre Genre { get; set; }
    public required string Name { get; set; }
    public required string CoverImageUrl { get; set; }
    public required string Description { get; set; }
    public required Guid StudioId { get; set; }
    public required DateOnly DateEstablished { get; set; }
}
