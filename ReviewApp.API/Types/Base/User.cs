using HotChocolate.Authorization;
using ReviewApp.API.Interfaces;

namespace ReviewApp.API.Types.Base;

[Authorize]
public class User : ICreatable, IModifiable
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string RemoteId { get; set; }
    public required UserRole Role { get; set; }

    public required DateTime CreatedAt { get; set; }
    public required string CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }
    public string? ModifiedBy { get; set; }
}

public enum UserRole
{
    User,
    Admin,
}

public static class Roles
{
    public const string Admin = "Admin";
    public const string User = "User";
}
