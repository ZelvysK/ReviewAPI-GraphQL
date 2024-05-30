using System.Security.Claims;
using ReviewApp.API.Types.Base;

namespace ReviewApp.API.Types.Queries;

[ExtendObjectType(Name = Constants.Query)]
public class MediaQueries
{
    [UseOffsetPaging]
    public IQueryable<Media> GetMedia(ReviewContext context, ClaimsPrincipal user)
    {
        return context.Media.AsQueryable();
    }
}
