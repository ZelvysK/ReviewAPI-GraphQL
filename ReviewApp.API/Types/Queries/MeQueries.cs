using HotChocolate.Authorization;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using ReviewApp.API.Errors;
using ReviewApp.API.Extensions;
using ReviewApp.API.Types.Base;

namespace ReviewApp.API.Types.Queries;

[QueryType]
public class MeQueries
{
    [Authorize]
    [Error<GqException>]
    public async Task<User> Me(ReviewContext reviewContext, IResolverContext context)
    {
        var userId = context.GetUserId();

        var user = await reviewContext
            .Users.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == userId);

        if (user is null)
        {
            throw new GqException(GqErrors.User.NotFound);
        }

        return user;
    }
}
