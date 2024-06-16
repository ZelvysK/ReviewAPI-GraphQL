using HotChocolate.Execution;

namespace ReviewApp.API.Errors;

public class StudioNotFoundError(string? message = "Studio not found")
    : QueryException(new ErrorBuilder().SetMessage(message).SetCode("STUDIO_NOT_FOUND").Build());