using HotChocolate.Execution;

namespace ReviewApp.API.Errors;

public class UserNotFoundError(string? message = "User not found")
    : QueryException(new ErrorBuilder().SetMessage(message).SetCode("USER_NOT_FOUND").Build());
