using HotChocolate.Execution;
using ReviewApp.API.Extensions;

namespace ReviewApp.API.Errors;

public class EntityNotFoundException(string typeName, string? message = null)
    : QueryException(
        new ErrorBuilder()
            .SetMessage(message ?? $"{typeName.ToFirstUpper()} not found")
            .SetCode($"{typeName.ToUpper()}_NOT_FOUND")
            .Build()
    );
