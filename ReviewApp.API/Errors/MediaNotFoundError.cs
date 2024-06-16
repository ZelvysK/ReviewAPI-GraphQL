using HotChocolate.Execution;

namespace ReviewApp.API.Errors;

public class MediaNotFoundError(string? message = "Media not found")
    : QueryException(new ErrorBuilder().SetMessage(message).SetCode("MEDIA_NOT_FOUND").Build());