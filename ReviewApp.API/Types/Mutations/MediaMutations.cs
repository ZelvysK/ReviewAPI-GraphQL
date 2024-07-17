using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;
using ReviewApp.API.Errors;
using ReviewApp.API.Extensions;
using ReviewApp.API.Types.Base;
using ReviewApp.API.Types.Inputs;

namespace ReviewApp.API.Types.Mutations;

[MutationType]
public class MediaMutations
{
    [Authorize]
    public async Task<Media> CreateMedia(
        ReviewContext reviewContext,
        CreateMediaInput input,
        ResolverContext context
    )
    {
        var userId = context.GetUserId();

        var media = new Media
        {
            MediaType = input.MediaType,
            Genre = input.Genre,
            Name = input.Name,
            CoverImageUrl = input.CoverImageUrl,
            Description = input.Description,
            StudioId = input.StudioId,
            DateEstablished = input.DateEstablished,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = userId.ToString(),
        };

        reviewContext.Media.Add(media);

        await reviewContext.SaveChangesAsync();

        return media;
    }

    [Authorize]
    public async Task<Media> UpdateMedia(
        ReviewContext reviewContext,
        UpdateMediaInput input,
        ResolverContext context
    )
    {
        var userId = context.GetUserId();

        var media = await reviewContext.Media.FindAsync(input.Id);

        if (media is null)
        {
            throw new EntityNotFoundException(nameof(Media));
        }

        media.MediaType = input.MediaType;
        media.Genre = input.Genre;
        media.Name = input.Name;
        media.CoverImageUrl = input.CoverImageUrl;
        media.Description = input.Description;
        media.StudioId = input.StudioId;
        media.DateEstablished = input.DateEstablished;

        media.ModifiedAt = DateTime.UtcNow;
        media.ModifiedBy = userId.ToString();

        await reviewContext.SaveChangesAsync();

        return media;
    }

    [Authorize]
    public async Task<Media> DeleteMedia(ReviewContext context, Guid id)
    {
        var media = await context.Media.FirstOrDefaultAsync(m => m.Id == id);

        if (media is null)
        {
            throw new EntityNotFoundException(nameof(Media));
        }

        context.Media.Remove(media);

        await context.SaveChangesAsync();

        return media;
    }
}
