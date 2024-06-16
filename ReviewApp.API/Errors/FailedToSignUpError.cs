using HotChocolate.Execution;

namespace ReviewApp.API.Errors;

public class FailedToSignUpError(string? message = "Failed to sign up")
    : QueryException(new ErrorBuilder().SetMessage(message).SetCode("FAILED_TO_SIGN_UP").Build());