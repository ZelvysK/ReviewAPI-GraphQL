using ReviewApp.API.Types.Enums;

namespace ReviewApp.API.Types.Inputs;

public class UpdateStudioInput
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public required string Headquarters { get; set; }
    public required string Founder { get; set; }
    public required DateOnly DateEstablished { get; set; }
    public required StudioType StudioType { get; set; }
}
