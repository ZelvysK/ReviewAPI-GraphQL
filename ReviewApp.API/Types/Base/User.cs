using HotChocolate.Authorization;

namespace ReviewApp.API.Types.Base;

[Authorize]
public class User
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string RemoteId { get; set; }
    public required UserRole Role { get; set; }
}

public enum UserRole
{
    User,
    Admin,
}
