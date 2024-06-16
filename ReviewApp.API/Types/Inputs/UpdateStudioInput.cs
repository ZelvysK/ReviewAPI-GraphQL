using ReviewApp.API.Types.Enums;

namespace ReviewApp.API.Types.Inputs;

public class UpdateStudioInput
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public required string Headquarters { get; set; }
    public required string Founder { get; set; }
    public required DateOnly DateFounded { get; set; }
    public required StudioType Type { get; set; }
}