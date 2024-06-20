using ReviewApp.API.Types.Enums;

namespace ReviewApp.API.Types.Inputs;

public record CreateMediaInput(
    MediaType MediaType,
    Genre Genre,
    string Name,
    string? CoverImageUrl,
    string? Description,
    Guid StudioId,
    DateOnly DateFounded
);
