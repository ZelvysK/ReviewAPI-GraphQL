using HotChocolate.Execution;

namespace ReviewApp.API.Errors;

public class FailedToSaveChangesError(string? message = "Failed to save changes")
    : QueryException(new ErrorBuilder().SetMessage(message).SetCode("FAILED_TO_SAVE_CHANGES").Build());