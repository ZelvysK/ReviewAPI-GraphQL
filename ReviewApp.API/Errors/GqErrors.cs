namespace ReviewApp.API.Errors;

public static class GqErrors
{
    public static class User
    {
        public const string NotFound = "USER_NOT_FOUND";
        public const string AlreadyExists = "USER_ALREADY_EXISTS";
    }

    public static class Entity
    {
        public const string NotFound = "ENTITY_NOT_FOUND";
        public const string AlreadyExists = "ENTITY_ALREADY_EXISTS";
    }

    public static class Auth
    {
        public const string SignInFailed = "SIGN_IN_FAILED";
        public const string SignUpFailed = "SIGN_UP_FAILED";
    }
}
