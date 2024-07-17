using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;
using ReviewApp.API.Types.Base;
using ReviewApp.API.Types.Enums;

namespace ReviewApp.API.Types.Queries;

public record GetStudiosInput(string? Term, StudioType? StudioType);

[QueryType]
public class StudioQueries
{
    [Authorize]
    [UseOffsetPaging(IncludeTotalCount = true, MaxPageSize = 10000)]
    public IQueryable<Studio> GetStudios(ReviewContext context, GetStudiosInput input)
    {
        var query = context.Studios.AsNoTracking().AsQueryable();

        if (string.IsNullOrWhiteSpace(input.Term) is false)
        {
            query = query.Where(x =>
                x.Name.Contains(input.Term)
                || x.Description != null && x.Description.Contains(input.Term)
                || x.Founder.Contains(input.Term)
            );
        }

        if (input.StudioType is not null)
        {
            query = query.Where(x => x.StudioType == input.StudioType);
        }

        return query.OrderByDescending(x => x.CreatedAt);
    }

    [Authorize]
    public Studio? GetStudioById(ReviewContext context, Guid id)
    {
        return context.Studios.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }
}
