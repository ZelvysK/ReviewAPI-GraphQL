using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;
using ReviewApp.API.Errors;
using ReviewApp.API.Types.Base;
using ReviewApp.API.Types.Inputs;

namespace ReviewApp.API.Types.Mutations;

[ExtendObjectType(Name = Constants.Mutation)]
public class MediaMutations
{
    [Authorize]
    public async Task<Media> CreateMedia(ReviewContext context, CreateMediaInput input)
    {
        var media = new Media
        {
            MediaType = input.MediaType,
            Genre = input.Genre,
            Name = input.Name,
            CoverImageUrl = input.CoverImageUrl,
            Description = input.Description,
            StudioId = input.StudioId,
            PublishedBy = input.PublishedBy,
            DateCreated = input.DateFounded,
            DatePosted = DateTime.Now
        };

        context.Media.Add(media);

        await context.SaveChangesAsync();

        return media;
    }

    [Authorize]
    public async Task<Media> UpdateMedia(ReviewContext context, UpdateMediaInput input)
    {
        var media = await context.Media.FirstOrDefaultAsync(m => m.Id == input.Id);

        if (media is null)
        {
            throw new MediaNotFoundError();
        }

        media.MediaType = input.MediaType;
        media.Genre = input.Genre;
        media.Name = input.Name;
        media.CoverImageUrl = input.CoverImageUrl;
        media.Description = input.Description;
        media.StudioId = input.StudioId;
        media.PublishedBy = input.PublishedBy;
        media.DateCreated = input.DateFounded;

        await context.SaveChangesAsync();

        return media;
    }

    [Authorize]
    public async Task<Media> DeleteMedia(ReviewContext context, Guid id)
    {
        var media = await context.Media.FirstOrDefaultAsync(m => m.Id == id);

        if (media is null)
        {
            throw new MediaNotFoundError();
        }

        context.Media.Remove(media);

        await context.SaveChangesAsync();

        return media;
    }
}
