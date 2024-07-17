using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;
using ReviewApp.API.Types.Base;
using ReviewApp.API.Types.Enums;

namespace ReviewApp.API.Types.Queries;

public record GetMediaInput(string? Term, MediaType? MediaType);

[QueryType]
public class MediaQueries
{
    [Authorize]
    [UseOffsetPaging(IncludeTotalCount = true)]
    public IQueryable<Media> GetMedia(ReviewContext context, GetMediaInput input)
    {
        var query = context.Media.AsNoTracking().AsQueryable();

        if (string.IsNullOrWhiteSpace(input.Term) is false)
        {
            query = query.Where(x =>
                x.Name.Contains(input.Term)
                || x.Description != null && x.Description.Contains(input.Term)
            );
        }

        if (input.MediaType is not null)
        {
            query = query.Where(x => x.MediaType == input.MediaType);
        }

        return query.OrderByDescending(x => x.CreatedAt);
    }

    [Authorize]
    public Media? GetMediaById(ReviewContext context, Guid id)
    {
        return context.Media.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }
}
