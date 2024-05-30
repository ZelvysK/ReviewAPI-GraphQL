using HotChocolate.Authorization;
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
}
