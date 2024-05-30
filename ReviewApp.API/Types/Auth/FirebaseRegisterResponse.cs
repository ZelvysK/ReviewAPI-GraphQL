namespace ReviewApp.API.Types.Auth;

public record FirebaseRegisterResponse(
    string Kind,
    string IdToken,
    string Email,
    string RefreshToken,
    string ExpiresIn,
    string LocalId
);
