using System.Security.Claims;
using HotChocolate.Authorization;
using ReviewApp.API.Types.Base;

namespace ReviewApp.API.Types.Queries;

[QueryType]
public class MediaQueries
{
    [Authorize]
    [UseOffsetPaging]
    public IQueryable<Media> GetMedia(ReviewContext context, ClaimsPrincipal user)
    {
        return context.Media.AsQueryable();
    }
}
