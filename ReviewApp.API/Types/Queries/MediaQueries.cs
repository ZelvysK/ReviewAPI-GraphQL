using System.Security.Claims;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;
using ReviewApp.API.Errors;
using ReviewApp.API.Extensions;
using ReviewApp.API.Types.Base;

namespace ReviewApp.API.Types.Queries;

[ExtendObjectType(Name = Constants.Query)]
public class MediaQueries
{
    [Authorize]
    [UseOffsetPaging]
    public IQueryable<Media> GetMedia(ReviewContext context, ClaimsPrincipal user)
    {
        return context.Media.AsQueryable();
    }
}

[ExtendObjectType(Name = Constants.Query)]
public class MeQueries
{
    [Authorize(Roles = [Roles.Admin])]
    public async Task<User> Me(ReviewContext context, ClaimsPrincipal claims)
    {
        var userId = claims.GetUserId();

        if (userId is null)
        {
            throw new UserNotFoundError();
        }

        var user = await context.Users.FirstAsync(x => x.RemoteId == userId);

        if (user is null)
        {
            throw new UserNotFoundError();
        }

        return user;
    }
}
