using System.Security.Claims;
using HotChocolate.Resolvers;
using ReviewApp.API.Errors;

namespace ReviewApp.API.Extensions;

public static class ResolverContextExtensions
{
    public static Guid GetUserId(this IResolverContext context)
    {
        var userId = context.GetUser()?.FindFirstValue("id");

        if (Guid.TryParse(userId, out var parsedUserId))
        {
            return parsedUserId;
        }

        throw new GqException(GqErrors.User.NotFound);
    }
}
