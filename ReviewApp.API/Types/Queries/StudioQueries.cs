using System.Security.Claims;
using HotChocolate.Authorization;
using ReviewApp.API.Types.Base;

namespace ReviewApp.API.Types.Queries;

[QueryType]
public class StudioQueries
{
    [Authorize]
    [UseOffsetPaging]
    public IQueryable<Studio> GetStudios(ReviewContext context, ClaimsPrincipal claimsPrincipal)
    {
        return context.Studios.AsQueryable();
    }
}
