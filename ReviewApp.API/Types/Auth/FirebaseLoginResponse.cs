namespace ReviewApp.API.Types.Auth;

public record FirebaseLoginResponse(
    string LocalId,
    string Email,
    string DisplayName,
    string IdToken,
    bool Registered,
    string RefreshToken,
    string ExpiresIn
);