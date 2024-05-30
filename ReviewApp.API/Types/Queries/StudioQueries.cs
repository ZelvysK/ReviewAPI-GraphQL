using System.Security.Claims;
using ReviewApp.API.Types.Base;

namespace ReviewApp.API.Types.Queries;

[ExtendObjectType(Name = Constants.Query)]
public class StudioQueries
{
    [UseOffsetPaging]
    public IQueryable<Studio> GetStudios(ReviewContext context, ClaimsPrincipal claimsPrincipal)
    {
        return context.Studios.AsQueryable();
    }
}
