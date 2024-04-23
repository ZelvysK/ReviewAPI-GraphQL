using ReviewApp.API.Types.Enums;

namespace ReviewApp.API.Types;

public class Studio
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string Headquarters { get; set; }
    public string Founder { get; set; }
    public DateOnly DateCreated { get; set; }
    public StudioType Type { get; set; }
}
